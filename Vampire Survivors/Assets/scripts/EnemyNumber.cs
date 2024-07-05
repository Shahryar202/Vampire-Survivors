using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EnemyNumber : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI EnemyText;
    int Kills = 0;

    public void numberOfKills(int num){
        Kills += num;
        SetEnemyText(Kills);
        String path = "C:\\GameTxtFiles\\Emtiaz.txt";
        String[] lines = File.ReadAllLines(path);
        if(lines.Length > 0){
            if(int.TryParse(lines[1], out int firstNumber)){
                firstNumber++;
                lines[1] = firstNumber.ToString();
                File.WriteAllLines(path, lines);
            }
        }
    }
    public void SetEnemyText(int EnemyNumbers){
        EnemyText.text =" "+  EnemyNumbers.ToString();
    }
}
