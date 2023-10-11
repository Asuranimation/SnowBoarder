using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float slideDuration = 1f;
    public Image panel;
    private bool isFading = false;

    private void Start()
    {
        StartCoroutine(SetFadeController());
    }

    IEnumerator SetFadeController()
    {
        StartFadeIn();
        yield return new WaitForSeconds(slideDuration);
        StartFadeOut();
    }

    public void StartFadeIn()
    {
        if (!isFading)
        {
            StartCoroutine(FadeIn());
        }
    }

    public void StartFadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        float elapsedTime = 0f;
        Color startColor = panel.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            panel.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel.color = targetColor;
        isFading = false;
    }

    private IEnumerator FadeOut()
    {
        isFading = true;
        float elapsedTime = 0f;
        Color startColor = panel.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < fadeDuration)
        {
            panel.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel.color = targetColor;
        isFading = false;
        
        LoadNextToMainMenu();
        
    }
    
    void LoadNextToMainMenu()
    {
        SceneManager.LoadScene(SceneName.MAIN_MENU);
    }
}

