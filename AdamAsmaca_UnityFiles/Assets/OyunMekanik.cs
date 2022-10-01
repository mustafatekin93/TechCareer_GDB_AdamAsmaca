using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class OyunMekanik : MonoBehaviour
{
    string[] kelimeler;
    string dosyaYolu;
    public string randomKelime;
    string tempText = "";
    static char tahminHarf;

    char[] _seciliKelime;
    List<char> seciliKelime = new List<char>();
    char[] tempTextList;
    bool[] harfGec;
    bool winGame = false;
    int hataSayac = 7;
    int dogruSayac = 0;

    public TMP_Text secilenKelime;
    public TMP_Text kalanHata;
    public GameObject tekrarButonu;
    public GameObject cikisButonu;

    public new AudioSource audio;
    public AudioClip endGameWinSound;
    public AudioClip endGameLoseSound;
    public AudioClip tahminSound;
    public AudioClip clickSound;
    public AudioClip wrongSound;
    public AnimationHandler animaton;

    void Start()
    {
        audio.volume = 0.1f;
        dosyaYolu = Application.dataPath + "/" + "kelimeler.txt";
        KelimeleriTanımla();
        tempTextList = new char[_seciliKelime.Length];
        for (int i = 0; i < _seciliKelime.Length; i++)
        {
            tempTextList[i] = '_';
        }
        for (int i = 0; i < tempTextList.Length; i++)
        {
            tempText += tempTextList[i];
        }
        secilenKelime.text = tempText;
        kalanHata.text = "KALAN HATA: " + hataSayac;

        harfGec = new bool[_seciliKelime.Length];
        for (int i = 0; i < harfGec.Length; i++)
        {
            harfGec[i] = false;
        }
    }

    void KelimeleriTanımla()
    {
        kelimeler = File.ReadAllLines(dosyaYolu);
        randomKelime = kelimeler[Random.Range(0, kelimeler.Length)];
        _seciliKelime = randomKelime.ToCharArray();

        for (int i = 0; i < _seciliKelime.Length; i++)
        {
            seciliKelime.Add(_seciliKelime[i]);
        }
    }

    public void tahminYap(char X)
    {
        tahminHarf = X;

        audio.PlayOneShot(clickSound);
        if (hataSayac > 0 && winGame == false)
        {
            if (seciliKelime.Contains(tahminHarf))
            {
                harfGoster(tahminHarf);
            }
            else
            {

                audio.PlayOneShot(wrongSound);
                hataSayac--;
                kalanHata.text = "KALAN HATA: " + hataSayac;
                if (hataSayac <= 0)
                {
                    StartCoroutine(oyunYenilgi());
                }
            }
        }
    }

    void Update()
    {
        if (_seciliKelime.Length == dogruSayac && winGame == false)
        {
            winGame = true;
            StartCoroutine(oyunKazanma());
        }
    }

    void harfGoster(char X)
    {
        for (int i = 0; i < _seciliKelime.Length; i++)
        {
            if (!harfGec[i])
            {
                if (X == _seciliKelime[i])
                {
                    tempTextList[i] = X;
                    harfGec[i] = true;
                    dogruSayac++;
                }
                else
                    tempTextList[i] = '_';
            }
        }

        tempText = "";
        for (int i = 0; i < tempTextList.Length; i++)
        {
            tempText += tempTextList[i];
        }
        secilenKelime.text = tempText;
    }

    public IEnumerator oyunYenilgi()
    {
        yield return new WaitForSeconds(1.5f);
        animaton.LoseAnimation();
        StartCoroutine(kelimeGöster());
        audio.PlayOneShot(endGameLoseSound);
        tekrarButonu.SetActive(true);
        cikisButonu.SetActive(true);
        this.enabled = false;
    }

    public IEnumerator oyunKazanma()
    {
        winGame = true;
        yield return new WaitForSeconds(1.5f);
        animaton.WinAnimation();
        StartCoroutine(kelimeGöster());
        audio.PlayOneShot(endGameWinSound);
        this.enabled = false;
        tekrarButonu.SetActive(true);
        cikisButonu.SetActive(true);
    }

    IEnumerator kelimeGöster()
    {
        yield return new WaitForSeconds(1.5f);
        secilenKelime.text = randomKelime;
    }

    public void tahminSes()
    {
        audio.PlayOneShot(tahminSound);
    }
}
