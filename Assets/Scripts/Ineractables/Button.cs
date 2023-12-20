using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public GameObject obj;
    private int count=0;
    
    public void Interact()
    {
        Debug.Log(Random.Range(0,100));
        Instantiate(obj);
        obj.transform.position = transform.position + new Vector3(-5, 0, 0);
        count++;
        if (count > 10)
            Destroy(obj);
        
    }
}
