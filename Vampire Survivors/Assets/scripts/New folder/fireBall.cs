using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;
    [SerializeField] GameObject FireBall;
    playerMovement2 playerMove;
    [SerializeField] public AudioSource sound;

    private void Awake(){
        playerMove = GetComponentInParent<playerMovement2>();
    }

    private void Update(){
        if(timer < timeToAttack){
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnFireBall();

    }

    private void SpawnFireBall(){
        GameObject thrownFireBall = Instantiate(FireBall);
        thrownFireBall.transform.position = transform.position;
        thrownFireBall.GetComponent<ThrowingFireBall>().SetDirection(playerMove.lastHorizontalVector, 0f);
        sound.Play();
    }

}
