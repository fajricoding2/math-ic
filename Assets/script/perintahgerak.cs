using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f;  // Kecepatan pergerakan objek

    void Update()
    {
        // Mengambil input dari sumbu horizontal (A, D atau ← →)
        float move = Input.GetAxis("Horizontal");

        // Menggerakkan objek ke kiri atau kanan
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }
}
