using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteksiJawaban : MonoBehaviour
{
    public bool jawabanTepat = false; // Menandakan apakah jawaban ini benar atau salah
    public GameObject senjata; // Objek senjata yang dilempar
    public GameObject umpanBalikBenar; // Objek umpan balik jika jawaban benar (misalnya, tanda centang)
    public GameObject umpanBalikSalah; // Objek umpan balik jika jawaban salah (misalnya, tanda silang)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mengecek jika senjata menabrak jawaban ini
        if (collision.gameObject == senjata)
        {
            // Menghentikan gerakan senjata
            senjata.GetComponent<LemparSenjata>().HentikanGerakan();

            // Menampilkan umpan balik sesuai dengan apakah jawabannya tepat atau tidak
            if (jawabanTepat)
            {
                umpanBalikBenar.SetActive(true); // Tampilkan tanda centang jika jawaban benar
            }
            else
            {
                umpanBalikSalah.SetActive(true); // Tampilkan tanda silang jika jawaban salah
            }
        }
    }
}
