using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrachDetector : MonoBehaviour
{
    public event Action crach;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeadPlayer"))
        {
            Debug.Log("GameOver");
            crach?.Invoke();
        }
    }

}
