using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerMovement2 : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    [HideInInspector] //this hide the below movementVector but it stays public
    public Vector3 movementVector;

    [HideInInspector]
    public float lastHorizontalVector;//stores the last input
    [HideInInspector]
    public float lastVerticalVector;
    
    [SerializeField] public float speed ; //the speed of the player movement We can change is it from unity
    Animate animate;
    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();   //initializing the vector of movement
        animate = GetComponent<Animate>(); //storing the reference to the animate object
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal"); //the input of the player movement
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
        
        movementVector *= speed;                //the speed of the movement
        rigidBody2d.velocity = movementVector;
    }
}
