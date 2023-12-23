using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score=0;
    public TextMeshPro text;
    public GameObject bird;
    public FlappyBird birdClass;
    public PipeSpawner pipeSpawner;
    private Rigidbody2D birdRB;
    private bool gameStarted = false;
    public void GameOver()
    {
        Debug.Log("Bird F");
        Start();

    }
    
    public void Start()
    {
        birdClass = GetComponentInChildren<FlappyBird>();
        pipeSpawner = GetComponentInChildren<PipeSpawner>();
        birdRB = bird.GetComponent<Rigidbody2D>();
        gameStarted = false;
        birdRB.Sleep();
        pipeSpawner.enabled = false;
        birdClass.Start();
        bird.transform.position= bird.transform.parent.position + new Vector3(3, 1, 2);
        
    }

    public void Update()
    {

        if (gameStarted == true)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                birdClass.Move();
                pipeSpawner.enabled = true;
                birdClass.enabled = true;
            }
        }
        else
        {
            score = 0;
            text.text = score.ToString();
            gameStarted = true;
        }

    }


    public void ScoreIncrease()
    {
        score++;
        text.text = score.ToString();
        
        
    }
}
