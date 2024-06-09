using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject quit;
    [SerializeField] private GameObject option;
    [SerializeField] private GameObject return1;

    
    private GameObject image;

    public void Play()
    {
        pause.SetActive(false);
        Time.timeScale = 0f;
        transform.position = transform.position + new Vector3(+Screen.width , 0, -1);
    }

    public void Resume(){
        pause.SetActive(true);
        Time.timeScale = 1f;
        transform.position = transform.position + new Vector3(-Screen.width , 0, -1);

    }

    public void Quit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Option(){
        transform.position = transform.position + new Vector3(+Screen.width , 0, -1);

    }

    public void Return(){
        transform.position = transform.position + new Vector3(-Screen.width , 0, -1);

    }




}
