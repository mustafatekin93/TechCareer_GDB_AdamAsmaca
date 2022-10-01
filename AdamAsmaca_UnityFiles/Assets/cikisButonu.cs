using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cikisButonu : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorPointer;
    public Animator butonAnimator;

    void OnMouseOver()
    {
        Cursor.SetCursor(cursorPointer, Vector2.zero, CursorMode.Auto);
        if (Input.GetMouseButtonDown(0))
        {
            butonAnimator.SetTrigger("isPressed");
            Application.Quit();
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }
}
