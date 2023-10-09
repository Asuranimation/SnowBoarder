using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] float powerBoost;
    [SerializeField] float durationBoost = 1f;
    float normalSpeed;

    private void Start()
    {
        normalSpeed = surfaceEffector.speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(BoosterCourotine());
        }
    }

    IEnumerator BoosterCourotine()
    {
        surfaceEffector.speed = powerBoost;
        yield return new WaitForSeconds(durationBoost);
        surfaceEffector.speed = normalSpeed;
    }

}
