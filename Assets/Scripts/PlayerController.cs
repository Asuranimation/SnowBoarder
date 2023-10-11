using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rb;

    bool rotateLeft = false;
    bool rotateRight = false;
    float valueTorque;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        valueTorque = torqueAmount * 100f;
    }

    void Update()
    {
        RotatePlayer();
        if (rotateLeft)
        {
            rb.AddTorque(-valueTorque * Time.deltaTime);
        }
        else if (rotateRight)
        {
            rb.AddTorque(valueTorque * Time.deltaTime);
        }
        else
        {
            rb.AddTorque(0f);
        }
    }

    void RotatePlayer()
    {
        float movement = Input.GetAxis("Horizontal");
        float valueTorque = torqueAmount * 100f;
        rb.AddTorque(-movement * valueTorque * Time.deltaTime);
    }

    public void RotatePlayerToRight() 
    {
        rotateLeft = true;
    }

    public void RotatePlayerToLeft()
    {
        rotateRight = true;
    }

    public float SetTorqueValue(float value)
    {
        return torqueAmount = value;
    }
}
