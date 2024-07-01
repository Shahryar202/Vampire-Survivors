using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnTimer2;
    [SerializeField] private float spawnTimer3;

    [SerializeField] private GameObject player;
    private float timer;
    private float timer2;
    private float timer3;

    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            SpawnEnemy();
            timer = 0f;
        }

        timer2 += Time.deltaTime;
        if (timer2 >= spawnTimer2)
        {
            SpawnEnemy2();
            timer2 = 0f;
        }

        timer3 += Time.deltaTime;
        if (timer3 >= spawnTimer3)
        {
            SpawnEnemy3();
            timer3 = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

        private void SpawnEnemy2()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;
        GameObject newEnemy = Instantiate(enemy2);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private void SpawnEnemy3()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;
        GameObject newEnemy = Instantiate(enemy3);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition() //this function make the bats be created out of the camera box
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        position.z = 0;

        return position;
    }
}
