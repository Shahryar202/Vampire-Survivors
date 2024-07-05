using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject health;
    GameObject player;
    [SerializeField] private int hpRecovery;

    public void Spawn(Vector3 position, Quaternion identity){
        Instantiate(health, position, identity);
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            player.GetComponent<StatusBar>().SetHealState(hpRecovery, 2000);

        }
    }
}