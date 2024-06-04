
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Page : MonoBehaviour
{
    private int a = 1;
    public Timer example;
    void Start()
    {
        example = GetComponent<Timer>();
    }
    public void NavigateToPage(int b){
        if(a==10&&b==0){
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
        else if(a==20&&b==0){
            transform.position = transform.position + new Vector3(-2*Screen.width , 0, 0);
        }
        else if(b==3){
            transform.position = transform.position + new Vector3(+2*Screen.width , 0, 0);
            a = 20;
        }
        else if(b==2){
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
            a = 10;
        }
        else if(b==4){
            example.to();
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
        }
        else if(b==1){
            example.ti();
            ResumeTimer();
            StartGameplay();
        }
        else if(b==6){
            PauseTimer();
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
        }
        else if(b==5){
            ResumeTimer();
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
        else if(b==7){
            example.ti();
            ResumeTimer();
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
        else if(b==8){
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
        }
        else if(b==9){
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
    }

    public void StartGameplay(){
        SceneManager.LoadScene("GamePlay");
    }

    private bool isPaused = false;
    private void PauseTimer()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }
    private void ResumeTimer()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
//0return option 10
//1start menu 1
//2option menu 1
//3option pause 30
//4quit pause 30
//5resume pause 30
//6pause game 20
