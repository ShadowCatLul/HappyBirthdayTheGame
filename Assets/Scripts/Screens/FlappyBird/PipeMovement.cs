using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeMovement : MonoBehaviour

{
    public float speed;
    private void FixedUpdate()
    {
        transform.position -= Vector3.left*speed;
    }
}
