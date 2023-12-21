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

    public void Move()
    {
        if (Input.GetKey(KeyCode.E))
            rb.velocity = Vector2.up * velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.parent.GetComponentInChildren<GameManager>().GameOver();
        }
        else if (other.gameObject.CompareTag("Score"))
        {
            transform.parent.GetComponentInChildren<GameManager>().ScoreIncrease();
        }
    }
}


