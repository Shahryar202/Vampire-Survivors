using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine.UI;

public class LevelUp2 : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar ExperienceBar;
    public GameObject levelUpPanel;
    public ThrowingFireBall fireBall;
    public playerMovement2 playerMovement;
    int SpeedLevel = 0;
    int weaponLevel = 0;

    [SerializeField] TMPro.TextMeshProUGUI CurrentSpeedLevelText;
    [SerializeField] TMPro.TextMeshProUGUI CurrentDamageLevelText;
    [SerializeField] TMPro.TextMeshProUGUI maxSpeedLevelText;
    [SerializeField] TMPro.TextMeshProUGUI maxDamageLevelText;
    [SerializeField] Button button;


    int TO_LEVEL_UP{
        get{
            return level * 1000;
        }
    }
    
    private void Start(){
        ExperienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        ExperienceBar.SetLevelText(level);
        levelUpPanel.SetActive(false);
    }

    public void AddExperience(int amount){
        experience += amount;
        CheckLevelUp();
        ExperienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp(){
        if(experience >= TO_LEVEL_UP){
            experience -= TO_LEVEL_UP;
            level += 1;
            PauseGame();
            ExperienceBar.SetLevelText(level);

            String path = "C:\\GameTxtFiles\\Emtiaz.txt";
            String[] lines = File.ReadAllLines(path);
            if(lines.Length > 0){
                if(int.TryParse(lines[2], out int firstNumber)){
                    firstNumber++;
                    lines[2] = firstNumber.ToString();
                 File.WriteAllLines(path, lines);
            }
        }
        }
    }

    void PauseGame(){
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true);
        if(SpeedLevel < 5 && weaponLevel < 5){
            CurrentSpeedLevelText.gameObject.SetActive(true);
            CurrentDamageLevelText.gameObject.SetActive(true);
            maxSpeedLevelText.gameObject.SetActive(false);
            maxDamageLevelText.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
           

        }
        else if(SpeedLevel >= 5 && weaponLevel < 5){
            CurrentSpeedLevelText.gameObject.SetActive(false);
            CurrentDamageLevelText.gameObject.SetActive(true);
            maxSpeedLevelText.gameObject.SetActive(true);
            maxDamageLevelText.gameObject.SetActive(false);
            button.gameObject.SetActive(false);

        }
        else if(SpeedLevel < 5 && weaponLevel >= 5){
            CurrentSpeedLevelText.gameObject.SetActive(true);
            CurrentDamageLevelText.gameObject.SetActive(false);
            maxSpeedLevelText.gameObject.SetActive(false);
            maxDamageLevelText.gameObject.SetActive(true);
            button.gameObject.SetActive(false);

        }
        else{
            CurrentSpeedLevelText.gameObject.SetActive(false);
            CurrentDamageLevelText.gameObject.SetActive(false);
            maxSpeedLevelText.gameObject.SetActive(true);
            maxDamageLevelText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }


    }

    public void SpeedUpgrade(){
        SpeedLevel++;
        playerMovement.speed = (float)(playerMovement.speed *1.1);
        resume();
    }

    public void DamegeUpgrade(){
        weaponLevel++;
        fireBall.damage = (int)(fireBall.damage*1.1);
        resume();
    }

    public void resume(){
        Time.timeScale = 1f;
        levelUpPanel.SetActive(false);
    }



}
