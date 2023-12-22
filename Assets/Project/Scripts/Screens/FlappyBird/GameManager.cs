using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour, IInteractable
{
    private int score=0;
    public TextMeshPro text;
    public GameObject bird;
    public FlappyBird birdClass;
    public PipeSpawner pipeSpawner;
    private bool gameStarted = false;
    public void GameOver()
    {
        Debug.Log("Bird F");
        gameStarted = false;

    }

    public void Interact()
    {
        if (gameStarted == true)
        {
            birdClass.Move(); 
        }
        else
        {
            gameStarted = true;
            pipeSpawner.enabled = true;
        }
    }

    public void Start()
    {
        birdClass = GetComponent<FlappyBird>();
        pipeSpawner = GetComponent<PipeSpawner>();
        gameStarted = false;
    }

    public void FixedUpdate()
    {
        if (!gameStarted)
        {
            score = 0;
            text.text = score.ToString();
            bird.transform.position = new Vector3(3, 0, 2);
            pipeSpawner.enabled = false;
        }


    }


    public void ScoreIncrease()
    {
        score++;
        text.text = score.ToString();
    }
}
