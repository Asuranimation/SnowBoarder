using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimple : MonoBehaviour
{
    [SerializeField] float valueRotate;
    void Start()
    {
        
    }

    void Update()
    {
        float moveR = Input.GetAxis("Horizontal") * valueRotate;
        transform.Rotate(Vector3.forward * moveR);
    }
}
