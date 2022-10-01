using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tahminButonu : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorPointer;
    [SerializeField] private Collider2D butonCollider;
    [SerializeField] private SpriteRenderer butonRenk;
    [SerializeField] private Animator butonAnimator;
    private OyunMekanik oyunMekanik;
    public TMP_InputField tahmin;

    void Start()
    {
        butonAnimator = transform.GetComponent<Animator>();
        butonRenk = GetComponent<SpriteRenderer>();
        butonCollider = GetComponent<Collider2D>();
        oyunMekanik = GameObject.Find("OyunMekanik").GetComponent<OyunMekanik>();
    }

    void OnMouseOver()
    {
        Cursor.SetCursor(cursorPointer, Vector2.zero, CursorMode.Auto);
        if (Input.GetMouseButtonDown(0))
        {
            butonAnimator.SetTrigger("isPressed");
            oyunMekanik.tahminSes();
            StartCoroutine(tahminState());
        }
    }

    IEnumerator tahminState()
    {
        yield return new WaitForSeconds(2f);
        if (oyunMekanik.randomKelime == tahmin.text.ToUpper())
        {
            StartCoroutine(oyunMekanik.oyunKazanma());
        }
        else
        {
            StartCoroutine(oyunMekanik.oyunYenilgi());
        }
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }

}
