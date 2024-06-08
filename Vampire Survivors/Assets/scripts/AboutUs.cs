using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutUs : MonoBehaviour
{
    public void OnClick(){
        transform.position = transform.position + new Vector3(-2*Screen.width , 0, 0);
    }
}
