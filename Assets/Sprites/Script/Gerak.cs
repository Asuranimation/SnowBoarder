using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerak : MonoBehaviour
{
    [SerializeField] float valueRotate;
    void Start()
    {
        
    }

   
    void Update()
    {
        float Rotate = Input.GetAxis("Horizontal") * valueRotate;
        transform.Rotate(Vector3.forward, Rotate);
    }
}
