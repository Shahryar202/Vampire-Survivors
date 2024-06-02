using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    [HideInInspector] //this hide the below movementVector but it stays public
    public Vector3 movementVector;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    
    [SerializeField] private float speed = 3f;
    Animate animate;
    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animate>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }

        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }
        animate.horizontal = movementVector.x;
        movementVector *= speed;
        rigidBody2d.velocity = movementVector;
    }
}
