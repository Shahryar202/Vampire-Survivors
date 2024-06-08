using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class whipWeapon : MonoBehaviour
{
    [SerializeField] public AudioSource sound;
    [SerializeField] private float timeToAttack = 4f;
    private float timer;

    [SerializeField] private GameObject leftWhipsGameObject;
    [SerializeField] private GameObject rightWhipsGameObject;

    private playerMovement playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
    [SerializeField] int whipDamage = 2;
    
    private void Awake()
    {
        playerMove = GetComponentInParent<playerMovement>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipsGameObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipsGameObject.transform.position, whipAttackSize, 0f);
            sound.Play();
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipsGameObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipsGameObject.transform.position, whipAttackSize, 0f);
            sound.Play();
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Enemy enemy = colliders[i].GetComponent<Enemy>();
            if (enemy != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamege(whipDamage);
            }
        }
    }
}
