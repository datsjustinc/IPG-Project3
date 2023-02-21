using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeType3 : CubeBase
{
    // range and midpoint of cube oscillation
    [SerializeField] private float speedMultiplier = 2.0f;
    [SerializeField] private float speedOffset = 1.0f;
    
    // overrides parent class Start function
    protected override void Start()
    {
        // set field variable of the base class
        base.RotateSpeed = 15f;
        base.mainCamera = Camera.main;
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
            // smooth oscillation over time
            var oscillation = Mathf.Cos(Time.time * speedMultiplier) + speedOffset;
            
            // rotate horizontally
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
    }

    // inherits parent class Rotate function
    protected override void Rotate()
    {
        base.Rotate();
    }
}
