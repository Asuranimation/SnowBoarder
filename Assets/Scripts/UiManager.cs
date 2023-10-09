using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject winCondition,loseCondition;
    [SerializeField] FinishLine finishLine;
    [SerializeField] CrachDetector crachDetector;

    private void Start()
    {
        finishLine.finished += OnFinishLineTriggered;
        crachDetector.crach += OnCrachTriggered;
    }

    private void OnFinishLineTriggered()
    {
        ShowUI(true);
    }

    private void OnCrachTriggered()
    {
        ShowUI(false);
    }

    void ShowUI(bool state)
    {
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
