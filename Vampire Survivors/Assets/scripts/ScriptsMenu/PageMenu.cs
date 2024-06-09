using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageMenu : MonoBehaviour
{
    public void NavigateToPage(float b){
        if(b>0&&b<1){
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
        else if(b>1&&b<2){
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
        }
        else if(b>2&&b<3){
            transform.position = transform.position + new Vector3(+Screen.width , 0, 0);
        }
    }
}
