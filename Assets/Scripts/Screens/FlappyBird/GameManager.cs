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
    public GameObject pipeSpawner;
    private bool gameStarted;
    public void GameOver()
    {
        Debug.Log("Bird F");
        gameStarted = false;

    }

    public void Interact()
    {
        gameStarted = true;
    }

    public void FixedUpdate()
    {
        if (gameStarted)
        {
            score = 0;
            text.text = score.ToString();
            bird.transform.position = new Vector3(3, 0, 2);
            gameStarted = false;
        }
        else
        {
            //Invoke(nameof(bird.GetComponentsInChildren<Move>()),1);
        }
    }


    public void ScoreIncrease()
    {
        score++;
        text.text = score.ToString();
    }
}
