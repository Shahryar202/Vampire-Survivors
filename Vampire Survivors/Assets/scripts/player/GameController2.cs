using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2 : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject cinema1;
    public GameObject cinema2;
    
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject world1;
    public GameObject world2;



    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        if (selectedCharacter == 1)
        {
            character1.SetActive(true);
            character2.SetActive(false);
            cinema1.SetActive(true);
            cinema2.SetActive(false);
            enemy1.SetActive(true);
            enemy2.SetActive(false);
            world1.SetActive(true);
            world2.SetActive(false);
        }
        else if (selectedCharacter == 2)
        {
            character1.SetActive(false);
            character2.SetActive(true);
            cinema1.SetActive(false);
            cinema2.SetActive(true);
            enemy1.SetActive(false);
            enemy2.SetActive(true);
            world1.SetActive(false);
            world2.SetActive(true);
        }
    }
}
