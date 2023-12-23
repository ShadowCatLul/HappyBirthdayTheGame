using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ButtonPlayer : MonoBehaviour, IInteractable
{
    public GameObject game;
    public GameManager gm;

    public void Start()
    {
        
        gm.enabled = false;
    }
    
    
    public void Interact()
    {
        gm.enabled = true;

    }
    
    
    
}
