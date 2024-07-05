using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StatusBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    [SerializeField] public Character player;
    public UnityEngine.UI.Image GameOverImage;

    void Start(){
        try{
        GameOverImage.gameObject.SetActive(false);
        }catch(Exception e){

        }
    }

    public void SetDamageState(int damage, int max)
    {
        float state = (float)player.currentHp-damage;
        player.currentHp = player.currentHp-damage;
        state /= max;
        if (state < 0f)
        {
            state = 0f;
            GameOverImage.gameObject.SetActive(true);
            Death();
        }

        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }

        public void SetHealState(int regeneration, int max)
    {
        float state = (float)player.currentHp+regeneration;
        if(player.currentHp+regeneration > player.maxHp){
            player.currentHp = player.maxHp;
        }
        else{
            player.currentHp = player.currentHp+regeneration;
        }
        state /= max;
        if (state < 0f)
        {
            state = 0f;
        }
        else if (state > 1f){
            state = 1f;
        }

        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
    public void Death(){
        SceneManager.LoadScene("File");
    }
}