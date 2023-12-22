using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float height=1f;
   
    public float spawnrate=1f;
    public GameObject pref;

    
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnrate, spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        
        GameObject pipe = Instantiate(pref, transform.position, Quaternion.identity);
        pipe.transform.position -= Vector3.up*spawnrate*Random.Range(-height, height);
    }
}
