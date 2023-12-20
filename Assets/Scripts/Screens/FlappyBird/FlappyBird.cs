using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{

    public float velocity = 1;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
     {
         if (Input.GetKey(KeyCode.E))
         {
             rb.velocity = Vector2.up * velocity;
         }
     }
}
