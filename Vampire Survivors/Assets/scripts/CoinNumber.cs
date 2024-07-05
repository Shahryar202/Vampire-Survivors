using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CoinNumber : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI CoinText;
    int coins = 0;

    public void numberOfCoins(int num){
        coins += num;
        SetCoinsText(coins);
        String path = "C:\\GameTxtFiles\\Emtiaz.txt";
        String[] lines = File.ReadAllLines(path);
        if(lines.Length > 0){
            if(int.TryParse(lines[0], out int firstNumber)){
                firstNumber++;
                lines[0] = firstNumber.ToString();
                File.WriteAllLines(path, lines);
            }
        }
    }
    public void SetCoinsText(int CoinsNumbers){
        CoinText.text =" "+  CoinsNumbers.ToString();
    }
}
