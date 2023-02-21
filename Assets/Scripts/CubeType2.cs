using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeType2 : CubeBase
{
    // cube scale factors
    [Serializable]
    private struct Factors
    {
        [SerializeField] public float scaleFactor;
        [SerializeField] public float speed;
        [SerializeField] public float minScale;
        [SerializeField] public float maxScale;
        [SerializeField] public float currentScale;
        [SerializeField] public int direction;
    }
    
    // create struct instance to modify variable group
    private Factors _scale;

    // overrides parent class Start function
    protected override void Start()
    {
        // set field variable of the base class
        base.RotateSpeed = 12f;
        base.mainCamera = Camera.main;
        
        // store current cube scale size and factors
        _scale.scaleFactor = 0.2f;
        _scale.speed = 1f;
        _scale.minScale = 0.5f;
        _scale.maxScale = 2f;
        _scale.currentScale = transform.localScale.x;
        _scale.direction = 1;
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
            _scale.currentScale += _scale.direction * _scale.scaleFactor * _scale.speed * Time.deltaTime;
            
            if (_scale.currentScale > _scale.maxScale || _scale.currentScale < _scale.minScale)
            {
                // grow or shrink based on min and max condition
                _scale.direction *= -1;
            }

            // update cube scale size
            transform.localScale = new Vector3(_scale.currentScale, _scale.currentScale, _scale.currentScale);
        }
    }

    // inherits parent class Rotate function
    protected override void Rotate()
    {
        base.Rotate();
    }
}
