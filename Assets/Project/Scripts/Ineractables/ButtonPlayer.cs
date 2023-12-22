using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEditorInternal;
using UnityEngine;

public class ButtonPlayer : MonoBehaviour, IInteractable
{
    public GameObject game;
    private GameManager bird;

    public void Start()
    {
        bird = GetComponent<GameManager>();
        bird.enabled = false;
    }
    

    public void Interact()
    {
        bird.enabled = true;

    }
    
    
    
}
