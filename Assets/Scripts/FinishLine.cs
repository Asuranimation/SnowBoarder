using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform spawnPosition;

    public event Action finished;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerPosition.position = spawnPosition.position;
        Debug.Log("SelamatAndaMenang");
        finished?.Invoke();
    }

}
