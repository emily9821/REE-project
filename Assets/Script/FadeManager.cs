using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image screen;
    private Color color;

    private static FadeManager I 
    {
        get
        {
            if (_fadeManager == null)
            {
                var fadeManager = FindObjectOfType<FadeManager>();
                _fadeManager = fadeManager == null ? Instantiate(Resources.Load<FadeManager>("Fade Manager")) : fadeManager;
            }
            return _fadeManager;
        }
        set { _fadeManager = value; }
    }
    private readonly WaitForSeconds waitTime = new WaitForSeconds(0.01f);
    private static FadeManager _fadeManager;

    public static void StartFadeOut()
    {
        I.FadeOut();
    }

    public static void StartFadeIn()
    {
        I.FadeIn();
    }

    public void FadeOut(float _speed =0.02f)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutCoroutine(_speed));

    }
    IEnumerator FadeOutCoroutine(float _speed)
    {
        color.a = 0f;
        //color = screen.color;

        while(color.a < 1f)
        {
            color.a += _speed;
            screen.color = color;
            yield return waitTime;
        }
    }

    public void FadeIn(float _speed =0.02f)
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(_speed));
    }

    IEnumerator FadeInCoroutine(float _speed)
    {
        color.a = 1f;
        //color = screen.color;

        while(color.a > 0f)
        {
            color.a -= _speed;
            screen.color = color;
            yield return waitTime;
        }
    }

    public void FlashOut(float _speed =0.02f)
    {
        StopAllCoroutines();
        StartCoroutine(FlashOutCoroutine(_speed));

    }
    IEnumerator FlashOutCoroutine(float _speed)
    {
        color.a = 0f;
        color = screen.color;

        while(color.a <1f)
        {
            color.a += _speed;
            screen.color = color;
            yield return waitTime;
        }
    }

    public void FlashIn(float _speed =0.02f)
    {
        StopAllCoroutines();
        StartCoroutine(FlashInCoroutine(_speed));

    }
    IEnumerator FlashInCoroutine(float _speed)
    {

        color = screen.color;

        while(color.a >0f)
        {
            color.a -= _speed;
            screen.color = color;
            yield return waitTime;
        }
    }
}
