using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] FinishLine finishLine;
    [SerializeField] CrachDetector crachDetector;
    [SerializeField] float timeToPlay;

    void Start()
    {
        finishLine.finished += StatePlayerFinish;
        crachDetector.crach += StatePlayerCrach;
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
        yield return new WaitForSeconds(timeToPlay);
    }

    IEnumerator StateCrachCourotine()
    {
        surfaceEffector.enabled = false;
        yield return new WaitForSeconds(timeToPlay);
    }

}
