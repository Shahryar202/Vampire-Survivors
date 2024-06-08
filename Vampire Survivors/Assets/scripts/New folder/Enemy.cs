using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDesitination;  //SerializedField added by shahryar
    private GameObject targetGameObject;
    Character targetCharacter;
    
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody2d;
    [SerializeField] private int hp = 200;
    [SerializeField] private int damage = 10;


    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        //targetGameObject = targetDesitination.gameObject;
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDesitination = target.transform;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (targetDesitination.position - transform.position).normalized;
        rigidBody2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            //Debug.Log("attack detected");
            Attack();    
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamege(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
