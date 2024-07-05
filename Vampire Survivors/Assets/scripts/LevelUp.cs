using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevelUp : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar ExperienceBar;

    int TO_LEVEL_UP{
        get{
            return level * 1000;
        }
    }
    
    private void Start(){
        ExperienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        ExperienceBar.SetLevelText(level);
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
}
