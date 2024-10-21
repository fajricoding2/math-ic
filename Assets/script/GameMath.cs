using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMath : MonoBehaviour {

    // Referensi ke elemen UI
    public TMP_Text p1, p2, text1, text2, operatorText;  // p= pernyataan, text= pertanyaan
    public Image gambar1, gambar2;
    public Button button1, button2, button3, button4;
    public TMP_Text textJawaban1, textJawaban2, textJawaban3, textJawaban4;
    public TMP_Text text_skor;

    // Daftar soal dan jawabannya
    public string[] per1, per2, soal1, soal2, operatorSoal, jawabanBenar; // per=pernyataan , soal=pertanyaan
    public Sprite[] gambarSoal1, gambarSoal2;
    public string[] pilihan1, pilihan2, pilihan3, pilihan4;

    // Feedback dan skor
    public GameObject feed_benar, feed_salah, selesai, bank_soal;
    int urutan_soal = -1, skor = 0;

    // Start is called before the first frame update
    void Start() {
        tampil_pernyataan();     
        // Menambahkan listener ke tombol jawaban
        button1.onClick.AddListener(() => jawab(textJawaban1.text));
        button2.onClick.AddListener(() => jawab(textJawaban2.text));
        button3.onClick.AddListener(() => jawab(textJawaban3.text));
        button4.onClick.AddListener(() => jawab(textJawaban4.text));
    }

    // Menampilkan pernyataan ke layar
    void tampil_pernyataan() {
        urutan_soal++;
        if (urutan_soal < per1.Length) {
            // Menampilkan teks pernyataan dan gambar
            p1.text = per1[urutan_soal];
            p2.text = per2[urutan_soal];
            text1.text = soal1[urutan_soal];
            text2.text = soal2[urutan_soal];
            gambar1.sprite = gambarSoal1[urutan_soal];
            gambar2.sprite = gambarSoal2[urutan_soal];
            operatorText.text = operatorSoal[urutan_soal];

            // Mengisi tombol dengan jawaban pilihan
            textJawaban1.text = pilihan1[urutan_soal];
            textJawaban2.text = pilihan2[urutan_soal];
            textJawaban3.text = pilihan3[urutan_soal];
            textJawaban4.text = pilihan4[urutan_soal];
        } else {
            // Jika soal habis, tampilkan pesan selesai
            selesai.SetActive(true);
            bank_soal.SetActive(false);
        }
    }

    // Logika ketika pemain memilih jawaban
    public void jawab(string jawaban) {
        if (urutan_soal < soal1.Length) {
            if (jawaban == jawabanBenar[urutan_soal]) {
                skor += 20;  // Tambah skor jika jawaban benar
                feed_benar.SetActive(true);
                feed_salah.SetActive(false);
            } else {
                feed_benar.SetActive(false);
                feed_salah.SetActive(true);
            }
            tampil_pernyataan();  // Tampilkan pernyataan berikutnya
        }
    }

    // Update skor di layar secara real-time
    void Update() {
        if (text_skor.text != skor.ToString()) {
            text_skor.text = skor.ToString();
        }
    }
}
