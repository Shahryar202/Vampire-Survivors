using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scnene1 : MonoBehaviour
{
    public void onclick(){
        SceneManager.LoadScene("GamePlay");
    }
}
