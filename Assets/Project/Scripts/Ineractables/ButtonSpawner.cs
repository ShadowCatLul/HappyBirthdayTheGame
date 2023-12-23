using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Button : MonoBehaviour, IInteractable
{
    public GameObject obj;
    public GameObject relatedTo;
    public Vector3 position;
    public void Interact()
    {
        Instantiate(obj, relatedTo.transform.position+position, Quaternion.identity);

    }
}
