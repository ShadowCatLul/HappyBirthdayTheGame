using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallCounter : MonoBehaviour
{
    public TextMeshPro ballCount;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ballCount.text = score.ToString();
        
    }

    // Update is called once per frame

    
    
    private void OnTriggerEnter(Collider collider)
    {
        score += 1;
        ballCount.text = score.ToString();
    }
}
