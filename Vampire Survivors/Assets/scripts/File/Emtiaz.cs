using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class Emtiaz : MonoBehaviour
{
    public TextMeshProUGUI a1;
    public TextMeshProUGUI a3;
    public TextMeshProUGUI a4;
    public string filePath = "C:\\GameTxtFiles\\Emtiaz.txt";
    void Start()
    {
        if(File.Exists(filePath)){
            string[] lines = File.ReadAllLines(filePath);
            if(lines.Length > 0){
                a1.text = lines[0];
                a3.text = lines[1];
                a4.text = lines[2];
            }
        }
    }
}
