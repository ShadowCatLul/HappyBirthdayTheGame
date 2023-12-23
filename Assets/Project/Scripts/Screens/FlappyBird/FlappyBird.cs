using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


public class FlappyBird : MonoBehaviour
{

    public float velocity = 3;
    private Rigidbody2D rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.Sleep();
    }

    public void Move()
    {
        rb.isKinematic = false;
        rb.velocity = Vector2.up * velocity*100*Time.deltaTime;
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


