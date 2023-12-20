using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeMovement : MonoBehaviour

{
    public float speed=1f;
    private float leftEdge;
    private void FixedUpdate()
    {
        transform.position -= Vector3.left*speed;
        if  (transform.position.x<leftEdge)
            Destroy(gameObject);
    }
    
}
