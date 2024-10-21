using UnityEngine;

public class CloudFall : MonoBehaviour
{
    // Menyimpan Rigidbody2D dari object awan
    private Rigidbody2D rb;

    void Start()
    {
        // Mendapatkan komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Fungsi ini akan dipanggil ketika object awan bertabrakan dengan object lain
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika object yang bertabrakan adalah senjata (shuriken)
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            // Mengaktifkan gravitasi pada object awan agar jatuh
            rb.gravityScale = 1f;
        }
    }
}
