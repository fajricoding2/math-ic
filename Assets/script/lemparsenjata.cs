using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemparsenjata : MonoBehaviour
{
    public GameObject senjata; // Objek senjata yang akan dilempar
    public float throwSpeed = 500.0f; // Kecepatan lemparan senjata
    public float maxThrowHeight = 300.0f; // Ketinggian maksimum senjata
    private bool isThrowing = false; // Status apakah senjata sedang dilempar
    private RectTransform senjataRectTransform;
    private Vector2 initialSenjataPosition; // Posisi awal senjata

    void Start()
    {
        // Mendapatkan komponen RectTransform dari senjata
        senjataRectTransform = senjata.GetComponent<RectTransform>();
        // Menyimpan posisi awal senjata
        initialSenjataPosition = senjataRectTransform.anchoredPosition;
    }

    void Update()
    {
        // Mengecek apakah tombol spasi ditekan dan senjata tidak sedang dilempar
        if (Input.GetKeyDown(KeyCode.Space) && !isThrowing)
        {
            StartCoroutine(ThrowSenjata());
        }
    }

    IEnumerator ThrowSenjata()
    {
        isThrowing = true; // Menandai bahwa senjata sedang dilempar

        // Posisi awal lemparan
        float startY = senjataRectTransform.anchoredPosition.y;
        float targetY = startY + maxThrowHeight;

        // Lempar senjata ke atas
        while (senjataRectTransform.anchoredPosition.y < targetY)
        {
            // Pergerakan senjata
            senjataRectTransform.anchoredPosition += new Vector2(0, throwSpeed * Time.deltaTime);

            // Cek tabrakan dengan objek yang jatuh
            if (CheckCollisionWithFallingObject())
            {
                // Berhenti jika mengenai objek
                break;
            }

            yield return null; // Tunggu frame berikutnya
        }

        // Setelah mencapai ketinggian maksimum, atau mengenai objek yang jatuh, turunkan senjata kembali ke posisi semula
        while (senjataRectTransform.anchoredPosition.y > initialSenjataPosition.y)
        {
            senjataRectTransform.anchoredPosition -= new Vector2(0, throwSpeed * Time.deltaTime);
            yield return null; // Tunggu frame berikutnya
        }

        // Reset status setelah lemparan selesai
        senjataRectTransform.anchoredPosition = initialSenjataPosition;
        isThrowing = false;
    }

    // Fungsi untuk memeriksa tabrakan antara senjata dan objek yang jatuh
    bool CheckCollisionWithFallingObject()
    {
        // Dapatkan semua objek dengan tag "fallingObject"
        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("fallingObject");

        foreach (GameObject obj in fallingObjects)
        {
            RectTransform objRectTransform = obj.GetComponent<RectTransform>();

            // Cek apakah rect dari senjata dan objek jatuh saling bertabrakan
            if (RectOverlaps(senjataRectTransform, objRectTransform))
            {
                Debug.Log("Senjata mengenai objek yang jatuh!");
                return true; // Ada tabrakan
            }
        }

        return false; // Tidak ada tabrakan
    }

    // Fungsi untuk mendeteksi overlap antara dua RectTransform
    bool RectOverlaps(RectTransform rect1, RectTransform rect2)
    {
        return rect1.rect.Overlaps(rect2.rect);
    }
}
