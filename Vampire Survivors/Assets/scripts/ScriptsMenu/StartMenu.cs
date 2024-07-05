using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnClick(){
        transform.position = transform.position + new Vector3(-3*Screen.width , 0, 0);

    }

}
