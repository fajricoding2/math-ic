using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f; // Kecepatan gerak karakter
    private RectTransform rectTransform; // Menggunakan RectTransform untuk mengetahui batas canvas
    private float canvasWidth; // Lebar dari canvas

    void Start()
    {
        // Mengambil komponen RectTransform
        rectTransform = GetComponent<RectTransform>();

        // Mendapatkan lebar canvas (CanvasScaler digunakan untuk layout UI di Unity)
        canvasWidth = rectTransform.rect.width * 3;
    }

    void Update()
    {
        // Mendapatkan input dari keyboard (panah kiri dan kanan atau A/D)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Menghitung pergerakan karakter
        Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        // Menggerakkan karakter
        rectTransform.anchoredPosition += new Vector2(movement.x, 0);

        // Batasi gerakan karakter di dalam batas canvas
        Vector3 newPos = rectTransform.anchoredPosition;
        newPos.x = Mathf.Clamp(newPos.x, -canvasWidth, canvasWidth);

        rectTransform.anchoredPosition = newPos;
    }


}
