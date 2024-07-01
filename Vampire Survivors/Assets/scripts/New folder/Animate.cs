using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;

    public float horizontal;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>(); //storing the reference to animate
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", horizontal); //here we are passing the horizontal value to the animator
    }
}
