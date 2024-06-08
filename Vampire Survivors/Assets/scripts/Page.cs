using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PAGE : MonoBehaviour
{
    private int a = 10;
    public void NavigateToPage(int b){
        if(b==10 && a==10){
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
        else if(b==20 && a==10){
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
        else if(b==30 && a==10){
            transform.position = transform.position + new Vector3(2*Screen.width , 0, 0);
        }
        else if(b==40){
            transform.position = transform.position + new Vector3(2*Screen.width , 0, 0);
            a = 50;
        }
        else if(b==50){
            transform.position = transform.position + new Vector3(3*Screen.width , 0, 0);
            a = 60;
        }
        else if(b==60){
            transform.position = transform.position + new Vector3(4*Screen.width , 0, 0);
            a = 70;
        }
        else if(b==20 && a==50){
            transform.position = transform.position + new Vector3(-2*Screen.width , 0, 0);
        }
        else if(b==20 && a==60){
            transform.position = transform.position + new Vector3(-3*Screen.width , 0, 0);
        }
        else if(b==20 && a==70){
            transform.position = transform.position + new Vector3(-4*Screen.width , 0, 0);
        }
        else if(b==70){
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
        }
        else if(b==80){
            transform.position = transform.position + new Vector3(+2*Screen.width , 0, 0);
        }
        else if(b==90){
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
        else if(b==100){
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
            a=100;
        }
        else if(b==110 && a==100){
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
            a=80;
        }
        else if(b==110 && a!=100){
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
        }
    }
}
