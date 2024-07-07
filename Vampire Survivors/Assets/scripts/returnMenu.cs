using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnMenu : MonoBehaviour
{
    public void OnClick(){
        transform.position = transform.position + new Vector3(-3*Screen.width , 0, 0);

    }
}
