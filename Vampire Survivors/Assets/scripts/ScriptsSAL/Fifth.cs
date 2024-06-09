using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Fifth : MonoBehaviour
{
    public TMP_InputField Pass;
    public TextMeshProUGUI Output;
    public AudioSource audioSource11;
    public AudioSource audioSource12;
    public void ButtonDemo(bool x){
        string s1 = Pass.text;
        if(string.IsNullOrEmpty(s1)){
            audioSource11.Play();
            Output.text = "Please Enter Your Password !!";
        }
        else if(!booliiiiii(s1)){
            audioSource12.Play();
            Output.text = "Your Password is Undefined Please Make its Structure";
        }
        else{
            string filePath = "D:\\projects\\MyProj\\Assets\\TextFilesUi\\line.txt";
            if(File.Exists(filePath)){
                string fileContent = File.ReadAllText(filePath);
                if (int.TryParse(fileContent, out int lineNumber)){
                    string filePath2 = "D:\\projects\\MyProj\\Assets\\TextFilesUi\\Password.txt";  
                            if (File.Exists(filePath2))
                                {
                                string[] lines = File.ReadAllLines(filePath2);
                                if (lines.Length < lineNumber)
                                {
                                Debug.LogError($"فایل کمتر از {lineNumber} خط دارد.");
                                return;
                                }
                                List<string> previousLines = lines.Take(lineNumber - 1).ToList();
                                previousLines.Add(s1);
                                if (lines.Length > lineNumber)
                                {
                                List<string> remainingLines = File.ReadAllLines(filePath2).Skip(lineNumber).ToList();
                                previousLines.AddRange(remainingLines);
                                }
                                File.WriteAllLines(filePath2, previousLines);
                                }
                                Menu1();
                }
            }
        }
    }
    private bool booliiiiii(string s1){
        string pattern = "\\b([0-9a-zA-Z]){5,15}\\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(s1);
    }
    public void Menu1(){
        SceneManager.LoadScene("Menu");
    }
}