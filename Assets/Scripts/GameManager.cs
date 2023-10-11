using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] FinishLine finishLine;
    [SerializeField] CrachDetector crachDetector;
    [SerializeField] ParticleSystem finishEffect,crashEffect;
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioClip finishSfx, crashSfx , winSFX,gameOverSFX;
    [SerializeField] float timeToPlay = 2f;

    bool hasFinished = true;
    bool hasCrashed = true;

    private void OnEnable()
    {
        finishLine.OnFinishedLineTriggered += StatePlayerFinish;
        crachDetector.OnCrachTriggered += StatePlayerCrach;
    }
    private void OnDisable()
    {
        finishLine.OnFinishedLineTriggered -= StatePlayerFinish;
        crachDetector.OnCrachTriggered -= StatePlayerCrach;
    }

    void StatePlayerFinish()
    {
        if(hasFinished)
        {
            StartCoroutine(StateFinishedCourotine());
            hasFinished = false;
        }
    }

    void StatePlayerCrach()
    {
        if (hasCrashed)
        {
            StartCoroutine(StateCrachCourotine());
            hasCrashed = false;
        }
    }

    IEnumerator StateFinishedCourotine()
    {
        surfaceEffector.enabled = false;
        playerController.enabled = false;
        AudioSource.PlayClipAtPoint(finishSfx, Camera.main.transform.position);
        finishEffect.Play();
        StartCoroutine(FadeOutVolumeCourotine());
        yield return new WaitForSeconds(timeToPlay);
        AudioSource.PlayClipAtPoint(winSFX,Camera.main.transform.position);
    }

    IEnumerator StateCrachCourotine()
    {
        surfaceEffector.enabled = false;
        playerController.enabled = false;
        AudioSource.PlayClipAtPoint(crashSfx,Camera.main.transform.position);
        crashEffect.Play();
        playerController.SetTorqueValue(0f);
        StartCoroutine(FadeOutVolumeCourotine());
        yield return new WaitForSeconds(timeToPlay);
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);

    }

    private IEnumerator FadeOutVolumeCourotine()
    {
        float fadeDuration = 1.0f;
        float startVolume = BGM.volume;
        float currentTime = 0;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            BGM.volume = Mathf.Lerp(startVolume, 0, currentTime / fadeDuration);
            yield return null;
        }

        BGM.volume = 0;
    }

}
