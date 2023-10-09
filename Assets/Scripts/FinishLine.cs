using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform spawnPosition;


    public event Action OnFinishedLineTriggered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SelamatAndaMenang");
        OnFinishedLineTriggered?.Invoke(); // ke GM
    }

}
