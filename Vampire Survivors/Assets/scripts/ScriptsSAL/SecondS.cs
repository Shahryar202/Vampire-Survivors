using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;
public class SecondS : MonoBehaviour
{
    public TMP_InputField Password;
    public TextMeshProUGUI Output;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public void ButtonDemo(int x){
        string s1 = Password.text;
        if(string.IsNullOrEmpty(s1)){
            audioSource4.Play();
            Output.text = "Please Enter Your Password !!";
        }
        else if(!boolii(s1)){
            audioSource5.Play();
            Output.text = "Your Password is Undefined Please Make its Structure";
        }
        else{
            string filePath = "C:/GameTxtFiles/password.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(s1);
            }
            transform.position = transform.position + new Vector3(-Screen.width , 0, 0);
        }
    }
    private bool boolii(string s1){
        string pattern = "\\b([0-9a-zA-Z]){5,15}\\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(s1);
    }
}
