using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextGame2 : MonoBehaviour
{
    public TextMeshProUGUI a1;
    public TextMeshProUGUI a3;
    public void OnClick()
    {
        startMenu();
    }

    public void startMenu()
    {
        string filePathhh = "C:\\GameTxtFiles\\user2.txt";
        string firstLine = ReadFirstLine(filePathhh);
        string filePath2 = "C:\\GameTxtFiles\\username.txt";
        (string matchedLine, int lineNumber) = FindMatchingLine(filePath2, firstLine);
        string[] data = matchedLine.Split(":");
        string coin = a1.text;
        string score = a3.text;
        if (data.Length == 1)
        {
            string answer = firstLine + ":" + coin + ":" + score;
            string fileName22 = "C:\\GameTxtFiles\\username.txt";
            ReplaceLineInFile(fileName22, lineNumber, answer);
        }
        else if (data.Length == 3)
        {
            int oldCoin = int.Parse(data[1]);
            int oldScore = int.Parse(data[2]);
            int newCoin = int.Parse(coin) + oldCoin;
            int newScore = int.Parse(score);
            if (newScore <= oldScore)
            {
                newScore = oldScore;
            }
            string answer = data[0] + ":" + newCoin.ToString() + ":" + newScore.ToString();
            string fileName22 = "C:\\GameTxtFiles\\username.txt";
            ReplaceLineInFile(fileName22, lineNumber, answer);
        }
        string filePath = "C:\\GameTxtFiles\\Emtiaz.txt";
        UpdateTextFile(filePath);
        SceneManager.LoadScene("GamePlay");
    }

    void UpdateTextFile(string filePath)
    {
        try
        {
            string[] newLines = { "0", "0", "1" };
            File.WriteAllLines(filePath, newLines);
        }
        catch (IOException e)
        {
            Debug.LogError("An error occurred while updating the file: " + e.Message);
        }
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

    void WriteStringToFile(string text, string filePath)
    {
        try
        {
            File.WriteAllText(filePath, text);
        }
        catch (IOException e)
        {
            Debug.LogError("An error occurred while writing to the file: " + e.Message);
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
}
