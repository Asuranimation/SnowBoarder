using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem trailParticle;
    float normalStartLifeTime;
    void Start()
    {
        normalStartLifeTime = trailParticle.startLifetime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        trailParticle.Play();
        trailParticle.startLifetime = normalStartLifeTime;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trailParticle.Stop();
        trailParticle.startLifetime = 0f;
    }

}
