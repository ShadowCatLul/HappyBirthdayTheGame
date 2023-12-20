using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject cam;
   
    
    void FixedUpdate()
    {
        cam.transform.position = gameObject.transform.position + new Vector3(0,0,0);
       

    }
    
    
    
    
    
}
