using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : MonoBehaviour, IInteractable
{
    
    public AudioClip[] musics;
    public AudioSource audioSource;
    private int count = 0;
    private int maxCount;

    public void Start()
    {
        
        musics[0] = null;
        foreach (AudioClip audio in musics)
        {
            count++;
        }

        maxCount = count;
        count = 0;
    }

    public void Interact()
    {
        ChangeMusic();

    }

    private void ChangeMusic()
    {
        if (count + 1 > maxCount)
            count = 0;
        audioSource.clip = musics[count];
        audioSource.Play();
        count += 1;

    }
  
}
