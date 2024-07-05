using System;
using System.IO; // اضافه کردن فضای نام‌های ضروری
using UnityEngine;
using TMPro;

public class Information : MonoBehaviour
{
    public TextMeshProUGUI a1;
    public TextMeshProUGUI a2;
    public TextMeshProUGUI a3;
    public TextMeshProUGUI a4;
    public TextMeshProUGUI a5;

    public void OnClick()
    {
        string filePathhh = "C:\\GameTxtFiles\\user2.txt";
        string firstLine = ReadFirstLine(filePathhh);
        a2.text = firstLine;

        string filePath2 = "C:\\GameTxtFiles\\username.txt";
        (string matchedLine, int lineNumber) = FindMatchingLine(filePath2, firstLine);



        string ppaatthh = "C:\\GameTxtFiles\\emails.txt";
        (string matchedLine55, int xxx) = Find(ppaatthh, lineNumber);
        a4.text = matchedLine55;
        string ppaatthh2 = "C:\\GameTxtFiles\\password.txt";
        (string matchedLine555, int yyy) = Find(ppaatthh2, lineNumber);
        a5.text = matchedLine555;







        if (matchedLine != null)
        {
            string[] data = matchedLine.Split(':');
            if (data.Length >= 3)
            {
                a1.text = data[1];
                a3.text = data[2]; // اصلاح: استفاده از a3 به جای a1
            }
            else if(data.Length==1){
                a1.text = "0";
                a3.text = "0";
            }
        }
        else
        {
            Debug.LogError("No matching line found.");
        }
        transform.position = transform.position + new Vector3(3 * Screen.width, 0, 0);
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


    (string, int) Find(string filePath, int lineNumber){
        try{
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int Number = 1;
                while((line = reader.ReadLine()) != null){
                    if(Number==lineNumber){
                        return (line, -1);
                    }
                    Number++;
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
