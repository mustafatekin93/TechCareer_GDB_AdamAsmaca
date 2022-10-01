using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class button : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorPointer;
    [SerializeField] private Collider2D butonCollider;
    [SerializeField] private SpriteRenderer butonRenk;
    [SerializeField] private TMP_Text butonHarf;
    [SerializeField] private Animator butonAnimator;
    private OyunMekanik oyunMekanik;
    private string tahminHarf;


    void Start()
    {
        butonAnimator = transform.GetComponent<Animator>();
        butonHarf = GetComponentInChildren<TMP_Text>();
        butonRenk = GetComponent<SpriteRenderer>();
        butonCollider = GetComponent<Collider2D>();
        oyunMekanik = GameObject.Find("OyunMekanik").GetComponent<OyunMekanik>();
    }

    void OnMouseOver()
    {
        Cursor.SetCursor(cursorPointer, Vector2.zero, CursorMode.Auto);
        if (Input.GetMouseButtonDown(0))
        {
            butonRenk.color = Color.gray;
            Destroy(butonCollider);
            butonAnimator.SetTrigger("isPressed");
            tahminHarf = butonHarf.text;
            char[] _tahminHarf = tahminHarf.ToCharArray();
            oyunMekanik.tahminYap(_tahminHarf[0]);
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }
}
