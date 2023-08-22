using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KuisManager : MonoBehaviour
{
    [Header("Pengaturan Halaman Menu")]
    public string halaman_menu;
    public string halaman_kuis_pertama;
    public string halaman_hasil;

    [Header("Pengaturan Halaman Kuis")]
    public string jawabanBenar;
    public int nilaiJawabanBenar;
    public string halamanSelanjutnya;
    public AudioSource suara;
    public AudioClip suaraBenar;
    public AudioClip suaraSalah;


    [Header("Pengaturan Halaman Hasil")]
    public Text text_nilai;
    public Text nama, kelas;
    public GameObject[] bintang;
    public int batas_bintang_1;
    public int batas_bintang_2;
    public int batas_bintang_3;
    public bool hasil;
    public int nilai;
    Scene activeScene;
    // Start is called before the first frame update
    void Start()
    {
        if (hasil)
        {
            nama.text = PlayerPrefs.GetString("nama");
            kelas.text = PlayerPrefs.GetString("kelas");
        }
        nilai = PlayerPrefs.GetInt("nilai");
        activeScene = SceneManager.GetActiveScene();

        if (activeScene.name == halaman_menu)
        {
            PlayerPrefs.SetString("hasil", halaman_hasil);
            PlayerPrefs.SetString("halaman_hasil", halaman_hasil);
            PlayerPrefs.SetString("halaman_kuis", halaman_kuis_pertama);
        }
        else if (activeScene.name == PlayerPrefs.GetString("halaman_kuis"))
        {
            PlayerPrefs.DeleteKey("nilai");
            Debug.Log("Ok" + PlayerPrefs.GetInt("nilai"));
            nilai = PlayerPrefs.GetInt("nilai");
        }
        else if (activeScene.name == PlayerPrefs.GetString("halaman_hasil"))
        {
            if (nilai <= batas_bintang_1)
            {
                bintang[0].SetActive(true);
                bintang[1].SetActive(false);
                bintang[2].SetActive(false);
            }
            else if (nilai <= batas_bintang_2)
            {
                bintang[0].SetActive(true);
                bintang[1].SetActive(true);
                bintang[2].SetActive(false);
            }
            else if (nilai <= batas_bintang_3)
            {
                bintang[0].SetActive(true);
                bintang[1].SetActive(true);
                bintang[2].SetActive(true);
            }
            text_nilai.text = nilai.ToString();
        }
    }

    public void PindahHalaman(string halaman)
    {
        SceneManager.LoadScene(halaman);
    }

    public void Jawaban_User(InputField jawaban)
    {
        StartCoroutine(Cek_Jawaban(jawaban.text));
    }

    IEnumerator Cek_Jawaban(string jawaban)
    {
        if (jawabanBenar.ToUpper() == jawaban.ToUpper())
        {
            nilai = nilai + nilaiJawabanBenar;
            PlayerPrefs.SetInt("nilai", nilai);
            suara.clip = suaraBenar;
            suara.Play();
        }
        else
        {
            suara.clip = suaraSalah;
            suara.Play();
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(halamanSelanjutnya);
    }

}
