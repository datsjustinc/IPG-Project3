using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeType4 : CubeBase
{
    // cube scale factors
    [SerializeField] private float scaleFactor;
    [SerializeField] private float speed;
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;
    [SerializeField] private float currentScale;
    [SerializeField] private int direction;

    // overrides parent class Start function
    protected override void Start()
    {
        // set field variable of the base class
        base.RotateSpeed = 12f;
        base.mainCamera = Camera.main;
        
        // store current cube scale size and factors
        scaleFactor = 0.2f;
        speed = 1f;
        minScale = 0.5f;
        maxScale = 2f;
        currentScale = transform.localScale.x;
        direction = 1;
    }

    // overrides parent class Update function
    protected override void Update()
    {
        // check if left mouse button is down
        if (Input.GetMouseButton(0))
        {
            base.Rotate();
        }
        else
        {
            // scale amount
            currentScale += direction * scaleFactor * speed * Time.deltaTime;
            
            if (currentScale > maxScale || currentScale < minScale)
            {
                // grow or shrink based on min and max condition
                direction *= -1;
            }

            // update cube scale size
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
    }

    // inherits parent class Rotate function
    protected override void Rotate()
    {
        base.Rotate();
    }
}
