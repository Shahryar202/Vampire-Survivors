using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnClick(){
        startGamePlay();
    }

    public void startGamePlay(){
        SceneManager.LoadScene("GameOver");
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1f;
        transform.position = transform.position + new Vector3(6*Screen.width , 0, 0);


    }
}
