using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver22 : MonoBehaviour
{
    public void OnClick(){
        startGamePlay();
        Time.timeScale = 1f;
    }
    public void startGamePlay(){
        SceneManager.LoadScene("File3");
    }
    
}