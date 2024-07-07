using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UpgradeCoinDamage : MonoBehaviour
{
    public TextMeshProUGUI a1;
    public TextMeshProUGUI level;
    public TextMeshProUGUI a2;
    public void OnClick(){
        string coin = a1.text;
        string stat = level.text;
        int addCoin = 20;
        int coinNumber = 0;

        if(int.Parse(coin) - int.Parse(stat) >= 0){
            coinNumber = int.Parse(coin) - int.Parse(stat);
            a1.text = coinNumber.ToString();
            level.text = (int.Parse(level.text) + addCoin).ToString();
        string filePathhh = "C:\\GameTxtFiles\\user2.txt";
        string firstLine = ReadFirstLine(filePathhh);
        string answer = firstLine + ":" + a1.text + ":" + a2.text;
        string filePath2 = "C:\\GameTxtFiles\\username.txt";
        (string matchedLine, int lineNumber) = FindMatchingLine(filePath2, firstLine);
        ReplaceLineInFile(filePath2, lineNumber, answer);
        }
    }
    void ReplaceLineInFile(string filePath, int lineNumber, string newLine)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lineNumber > 0 && lineNumber <= lines.Length)
            {
                lines[lineNumber - 1] = newLine;
                File.WriteAllLines(filePath, lines);
            }
            else
            {
            }
        }
        catch (IOException e)
        {
            Debug.LogError("An error occurred while reading or writing the file: " + e.Message);
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
}
