using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using System.IO;
public class ForthF : MonoBehaviour
{
    public TMP_InputField Password;
    public TextMeshProUGUI Output;
    public AudioSource audioSource8;
    public AudioSource audioSource9;
    public AudioSource audioSource10;
    public void ButtonDemo(float y){
        string s1 = Password.text;
        if(string.IsNullOrEmpty(s1)){
            audioSource8.Play();
            Output.text = "Please Enter Your Password !!";
        }
        else if(!booliiii(s1)){
            audioSource9.Play();
            Output.text = "Your Password is Undefined Please Make Its Structure";
        }
        else{
            string PassFile = "";
            int linenumber = -1;
            string filePath = "D:\\projects\\MyProj\\Assets\\TextFilesUi\\loop.txt";
            string firstLine = "";
            if (File.Exists(filePath)){
                try
                {
                firstLine = File.ReadLines(filePath).First();
                }
                catch (IOException e)
                {
                Debug.LogError("Error reading the file: " + e.Message);
                }
                if (!string.IsNullOrEmpty(firstLine)){
                string filePath2 = "D:\\projects\\MyProj\\Assets\\TextFilesUi\\emails.txt";
                if(File.Exists(filePath2))
                {
                    try
                    {
                        string[] searchLines = File.ReadAllLines(filePath2);
                        for (int j = 0; j < searchLines.Length; j++)
                        {
                            if (searchLines[j].Contains(firstLine))
                            {
                                linenumber = j + 1;
                                string filePath5 = "D:\\projects\\MyProj\\Assets\\TextFilesUi\\line.txt";
                                using (StreamWriter writer = new StreamWriter(filePath5))
                                {
                                writer.WriteLine(linenumber);
                                }
                                break;
                            }
                        }
                    }
                    catch(IOException e){
                    Debug.LogError("Error reading the file: " + e.Message);
                    }
                    string filePath3 = "D:\\projects\\MyProj\\Assets\\TextFilesUi\\Password.txt";
                    if(File.Exists(filePath3)){
                        try
                        {
                            PassFile = File.ReadAllLines(filePath3)[linenumber-1];
                        }
                        catch(IOException e){
                        Debug.LogError("Error reading the file: " + e.Message);
                        }
                        if(PassFile == Password.text){
                            transform.position = transform.position + new Vector3(-6*Screen.width, 0, 0);
                        }
                        else{
                            audioSource10.Play();
                            Output.text = "Your Password Is Incorrect";
                        }
                    }
                }
                }
            }
        }
    }
    private bool booliiii(string s1){
        string pattern = "\\b([0-9a-zA-Z]){5,15}\\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(s1);
    }
}