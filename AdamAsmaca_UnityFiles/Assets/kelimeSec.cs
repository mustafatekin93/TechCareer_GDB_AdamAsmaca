using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class kelimeSec : MonoBehaviour
{
    string[] kelimeler;
    string dosyaYolu;
    public static string randomKelime;
    public TMP_Text secilenKelime;

    // Start is called before the first frame update
    void Awake()
    {
        dosyaYolu = Application.dataPath + "/" + "kelimeler.txt";
        KelimeleriTanımla();
    }

    void KelimeleriTanımla()
    {
        kelimeler = File.ReadAllLines(dosyaYolu);
        //Debug.Log(kelimeler[Random.Range(0, kelimeler.Length)]);
        randomKelime = kelimeler[Random.Range(0, kelimeler.Length)];
        secilenKelime.text = randomKelime;
    }
}
