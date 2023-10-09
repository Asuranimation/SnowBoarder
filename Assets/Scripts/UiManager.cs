using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject winCondition,loseCondition;
    [SerializeField] FinishLine finishLine;
    [SerializeField] CrachDetector crachDetector;

    [SerializeField] float delayShowUI = 1f;

    private void Start()
    {
        finishLine.OnFinishedLineTriggered += delegate { ShowUICondition(true); };
        crachDetector.OnCrachTriggered += delegate { ShowUICondition(false); };
    }

    void ShowUICondition(bool value)
    {
        StartCoroutine(ShowUICourotine(value));
    }

    IEnumerator ShowUICourotine(bool state)
    {
        yield return new WaitForSeconds(delayShowUI);
        if (state)
        {
            winCondition.SetActive(true);
        }
        else
        {
            loseCondition.SetActive(true);
        }
    }

}
