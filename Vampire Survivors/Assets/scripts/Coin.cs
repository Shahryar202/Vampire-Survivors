// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Coin : MonoBehaviour
// {
//     [SerializeField] private GameObject coin;
//     [SerializeField] private Vector2 spawnArea;
//     [SerializeField] private float spawnTimer;
//     [SerializeField] private GameObject player;
//     private float timer;

    
//     CoinNumber coinNum;


//     private void Awake(){
//         coinNum = GameObject.FindWithTag("counter2").GetComponent<CoinNumber>();
//     }
//     private void Start()
//     {
//         player = GameObject.FindWithTag("Player");
//     }

//      private void Update()
//     {

//         timer += Time.deltaTime;
   
//         if (timer >= spawnTimer)
//         {
        
//             Spawn();
//             timer = 0f;
//             System.Random random = new System.Random();
//             int randomIntMax = random.Next(5)+5;
//             spawnTimer = randomIntMax;
//         }
//     } 

//     void Spawn(){
//         Vector3 position = GenerateRandomPosition();

//         position += player.transform.position;
//         GameObject newCoin = Instantiate(coin);
//         newCoin.transform.position = position;
//         newCoin.transform.parent = transform;
     
//     }   

//         private Vector3 GenerateRandomPosition()
//     {
//         Vector3 position = new Vector3();
//         float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
//         if (UnityEngine.Random.value > 0.5f)
//         {
//             position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
//             position.y = spawnArea.y * f;
//         }
//         else
//         {
//             position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
//             position.x = spawnArea.x * f;
//         }
//         position.z = 0;

//         return position;
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         Debug.Log("Coin collided with: " + other.gameObject.name);
//         if (other.gameObject == player) {
//             Debug.Log("Coin collected by player");
//             Destroy(gameObject);
//             coinNum.numberOfCoins(1);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject coin; // Ensure this is assigned in the Inspector
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject player; // Ensure this is assigned in the Inspector or use GameObject.FindWithTag("Player")
    private float timer;

    CoinNumber coinNum;

    private void Awake()
    {
        coinNum = GameObject.FindWithTag("counter2")?.GetComponent<CoinNumber>();
        if (coinNum == null)
        {
            //Debug.LogError("CoinNumber component not found. Ensure the GameObject with tag 'counter2' has the CoinNumber component.");
        }
    }

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                //Debug.LogError("Player GameObject not found. Ensure the player GameObject is tagged as 'Player'.");
            }
        }

        if (coin == null)
        {
            //Debug.LogError("Coin prefab not assigned. Please assign the coin prefab in the Inspector.");
        }
    }

    private void Update()
    {
        if (coin == null || player == null) return; // Early exit if critical references are missing

        timer += Time.deltaTime;

        if (timer >= spawnTimer)
        {
            Spawn();
            timer = 0f;
            System.Random random = new System.Random();
            int randomIntMax = random.Next(5) + 5;
            spawnTimer = randomIntMax;
        }
    }

    void Spawn()
    {
        if (coin == null || player == null) return; // Early exit if critical references are missing

        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;
        GameObject newCoin = Instantiate(coin);
        newCoin.transform.position = position;
        newCoin.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Coin collided with: " + other.gameObject.name);
        if (other.gameObject == player)
        {
            //Debug.Log("Coin collected by player");
            Destroy(gameObject);
            if (coinNum != null)
            {
                coinNum.numberOfCoins(1);
            }
            else
            {
                //Debug.LogError("coinNum is not assigned.");
            }
        }
    }
}
