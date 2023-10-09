using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] FinishLine finishLine;
    [SerializeField] CrachDetector crachDetector;
    [SerializeField] ParticleSystem finishEffect,crachEffect;
    [SerializeField] float timeToPlay;

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
        StartCoroutine(StateFinishedCourotine());
    }

    void StatePlayerCrach()
    {
        StartCoroutine(StateCrachCourotine());
    }

    IEnumerator StateFinishedCourotine()
    {
        surfaceEffector.enabled = false;
        playerController.enabled = false;
        finishEffect.Play();
        yield return new WaitForSeconds(timeToPlay);
    }

    IEnumerator StateCrachCourotine()
    {
        surfaceEffector.enabled = false;
        playerController.enabled = false;
        crachEffect.Play();
        playerController.SetTorqueValue(0f);
        yield return new WaitForSeconds(timeToPlay);
    }

}
