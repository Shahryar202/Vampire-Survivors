using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradePanel : MonoBehaviour
{
    public TextMeshProUGUI a1;
    public TextMeshProUGUI a2;
    public void OnClick(){
        string filePathhh = "C:\\GameTxtFiles\\user2.txt";
        string firstLine = ReadFirstLine(filePathhh);
        string filePath2 = "C:\\GameTxtFiles\\username.txt";
        (string matchedLine, int lineNumber) = FindMatchingLine(filePath2, firstLine);
        string[] data = matchedLine.Split(":");
        if(data.Length == 1){
            a1.text = "0";
            a2.text = "0";
        }
        else{
            a1.text = data[1];
            a2.text = data[2];
        }
        transform.position = transform.position + new Vector3(+3*Screen.width , 0, 0);
    }
    string ReadFirstLine(string filePath)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadLine();
            }
        }
        catch (IOException e)
        {
            Debug.LogError("An error occurred while reading the file: " + e.Message);
            return null;
        }
    }
    (string, int) FindMatchingLine(string filePath, string startString)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int lineNumber = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (line.StartsWith(startString))
                    {
                        return (line, lineNumber);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Debug.LogError("An error occurred while reading the file: " + e.Message);
        }
        return (null, -1);
    }
}
