using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrachDetector : MonoBehaviour
{
    public event Action OnCrashTriggered;
    Collider2D colider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeadPlayer"))
        {
            colider = collision.GetComponent<Collider2D>();
            colider.isTrigger = false;
            OnCrashTriggered?.Invoke(); // keGm
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Head head = collision.gameObject.GetComponent<Head>();
    //    if(head != null)
    //    {
    //        Debug.Log("GameOver");
    //        crach?.Invoke();
    //    }
    //}

}
