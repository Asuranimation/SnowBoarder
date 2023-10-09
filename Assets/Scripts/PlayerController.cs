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

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        float valueTorque = torqueAmount * 100f;
        rb.AddTorque(-movement * valueTorque * Time.deltaTime);
    }

    public float SetTorqueValue(float value)
    {
        return torqueAmount = value;
    }
}
