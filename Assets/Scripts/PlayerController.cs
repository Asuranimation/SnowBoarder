using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        float movement = Input.GetAxis("Horizontal");
        float speedRotate = movement * torqueAmount * 100f * Time.deltaTime;
        rb.AddTorque(-speedRotate);
    }

    public float SetTorqueValue(float value)
    {
        return torqueAmount = value;
    }
}
