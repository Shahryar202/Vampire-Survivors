using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    public void SelectCharacter1()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 1);
        LoadGameScene();
    }

    public void SelectCharacter2()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 2);
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
