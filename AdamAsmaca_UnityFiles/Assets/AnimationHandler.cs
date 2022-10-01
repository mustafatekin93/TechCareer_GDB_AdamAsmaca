using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationHandler : MonoBehaviour
{
    public Animator cellatAnimator;
    public Animator mahkumAnimator;
    public Animator daragaciAnimator;

    public void WinAnimation()
    {
        StartCoroutine(cellatAnimation());
        StartCoroutine(daragaciAnimation());
        StartCoroutine(mahkumWinAnimation());
    }
    public void LoseAnimation()
    {
        StartCoroutine(cellatAnimation());
        StartCoroutine(daragaciAnimation());
        StartCoroutine(mahkumLoseAnimation());
    }

    IEnumerator cellatAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        cellatAnimator.SetTrigger("isPull");
    }

    IEnumerator daragaciAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        daragaciAnimator.SetTrigger("isOpen");
    }
    IEnumerator mahkumWinAnimation()
    {
        yield return new WaitForSeconds(0.55f);
        mahkumAnimator.SetTrigger("isEscape");
    }
    IEnumerator mahkumLoseAnimation()
    {
        yield return new WaitForSeconds(0.55f);
        mahkumAnimator.SetTrigger("isHang");
    }
}
