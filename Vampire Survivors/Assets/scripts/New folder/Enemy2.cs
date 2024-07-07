using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] Transform targetDesitination;  //SerializedField added by shahryar
    private GameObject targetGameObject;
    Character targetCharacter;
    
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody2d;
    [SerializeField] private int hp = 50;
    [SerializeField] private int damage = 1;

    [SerializeField] private GameObject experience;
    [SerializeField] private GameObject health;

    EnemyNumber count;
    

    private void Awake()
    {
        count = GameObject.FindWithTag("counter").GetComponent<EnemyNumber>();
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
        Vector3 direction = (targetDesitination.position - transform.position).normalized; //the direction of the enemy we subtract the position of the character from the target position
        //normalized is the vector with length of 1 but with same direction
        rigidBody2d.velocity = direction * speed; //setting the speed of the enemy
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
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
            System.Random random = new System.Random();
            int randomIntMax = random.Next(10); // Range: 0 to 9

            if(randomIntMax >= 8){
                health.GetComponent<Health>().Spawn(transform.position, Quaternion.identity);
            }
            else{
                experience.GetComponent<Experience2>().Spawn(transform.position, Quaternion.identity);
            }
            count.numberOfKills(1);
        }
    }
}
