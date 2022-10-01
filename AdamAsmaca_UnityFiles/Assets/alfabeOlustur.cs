using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class alfabeOlustur : MonoBehaviour
{
    char[] alfabe = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };
    public GameObject butonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < alfabe.Length; i++)
        {
            GameObject buton = Instantiate(butonPrefab, Vector3.zero, Quaternion.identity);
            buton.GetComponentInChildren<TMP_Text>().text = alfabe[i].ToString();
            buton.transform.SetParent(transform);
        }

        Debug.Log("Done!");
    }
}
