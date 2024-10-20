using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerakjatuhjawaban : MonoBehaviour
{
    public float fallSpeed = 200.0f;  // Kecepatan jatuh
    public float bottomLimit = -500.0f;  // Batas bawah sebelum berhenti jatuh

    private RectTransform rectTransform;

    void Start()
    {
        // Mendapatkan komponen RectTransform dari objek jawaban
        rectTransform = GetComponent<RectTransform>();

        // Menempatkan objek di luar layar (di atas canvas)
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, Screen.height);
    }

    void Update()
    {
        // Menggerakkan objek ke bawah dengan kecepatan fallSpeed
        rectTransform.anchoredPosition += new Vector2(0, -fallSpeed * Time.deltaTime);

        // Berhenti jatuh ketika mencapai batas bawah
        if (rectTransform.anchoredPosition.y <= bottomLimit)
        {
            // Berhenti di posisi tertentu atau lakukan aksi lainnya
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, bottomLimit);
        }
    }
}
