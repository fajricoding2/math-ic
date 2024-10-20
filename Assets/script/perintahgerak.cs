using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKarakter : MonoBehaviour
{
    public float speed = 5.0f;  // Kecepatan pergerakan objek

    private RectTransform karakterRectTransform;
    private RectTransform inputJawabanRectTransform;

    void Start()
    {
        // Mendapatkan komponen RectTransform dari karakter dan input_jawaban
        karakterRectTransform = GetComponent<RectTransform>();
        inputJawabanRectTransform = GameObject.Find("input_jawaban").GetComponent<RectTransform>();
    }

    void Update()
    {
        // Mengambil input dari sumbu horizontal (A, D atau ← →)
        float move = Input.GetAxis("Horizontal");

        // Hitung posisi baru yang diinginkan
        Vector2 newPosition = karakterRectTransform.anchoredPosition + new Vector2(move * speed * Time.deltaTime, 0);

        // Dapatkan ukuran RectTransform dari karakter dan input_jawaban
        Vector2 karakterSize = karakterRectTransform.sizeDelta;
        Vector2 inputJawabanSize = inputJawabanRectTransform.sizeDelta;

        // Hitung batas kiri dan kanan dari input_jawaban
        float minX = inputJawabanRectTransform.anchoredPosition.x - inputJawabanSize.x / 2 + karakterSize.x / 2;
        float maxX = inputJawabanRectTransform.anchoredPosition.x + inputJawabanSize.x / 2 - karakterSize.x / 2;

        // Terapkan batasan pergerakan menggunakan Mathf.Clamp
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Update posisi karakter berdasarkan input yang sudah dibatasi
        karakterRectTransform.anchoredPosition = newPosition;
    }
}
