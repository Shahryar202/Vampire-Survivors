using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience2 : MonoBehaviour
{
    [SerializeField] private GameObject experience;
    int experience_reward = 400;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Spawn(Vector3 position, Quaternion identity){
        Instantiate(experience, position, identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            player.GetComponent<LevelUp2>().AddExperience(experience_reward);

        }
    }
}
