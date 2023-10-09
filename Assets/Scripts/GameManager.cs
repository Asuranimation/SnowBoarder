using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] FinishLine finishLine;
    [SerializeField] float timeToPlay;

    void Start()
    {
        finishLine.finished += RunStateSurfaceEffector;
    }

    void RunStateSurfaceEffector()
    {
        StartCoroutine(StateSurfaceEffector());
    }

    IEnumerator StateSurfaceEffector()
    {
        surfaceEffector.enabled = false;
        yield return new WaitForSeconds(timeToPlay);
        surfaceEffector.enabled = true;
    }
}
