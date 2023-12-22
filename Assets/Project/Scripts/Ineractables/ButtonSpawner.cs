using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Button : MonoBehaviour, IInteractable
{
    public GameObject obj;
    public GameObject relatedTo;
    private int count = 0;
    public Vector3 position;
    public void Interact()
    {
        Debug.Log(Random.Range(0,100));
        Instantiate(obj);
        obj.transform.position = relatedTo.transform.position + position;
        count++;
        if (count > 10)
            Destroy(obj);
        
    }
}
