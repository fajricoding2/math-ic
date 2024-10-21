using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemparSenjata : MonoBehaviour
{
    public float lemparKecepatan = 10f; // Kecepatan senjata saat dilempar
    private bool isThrown = false; // Status apakah senjata sudah dilempar atau belum

    void Update()
    {
        // Mengecek jika tombol spasi ditekan dan senjata belum dilempar
        if (Input.GetKeyDown(KeyCode.Space) && !isThrown)
        {
            isThrown = true; // Tandai bahwa senjata sudah dilempar
        }

        // Jika senjata sudah dilempar, senjata bergerak ke atas
        if (isThrown)
        {
            transform.Translate(Vector2.up * lemparKecepatan * Time.deltaTime);
        }
    }

    // Fungsi untuk menghentikan gerakan senjata
    public void HentikanGerakan()
    {
        isThrown = false; // Menghentikan lemparan senjata
    }
}
