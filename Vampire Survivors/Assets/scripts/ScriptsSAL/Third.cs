using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class ThirdT : MonoBehaviour
{
    public TMP_InputField UserName;
    public TextMeshProUGUI Output;
    public AudioSource audioSource6;
    public AudioSource audioSource7;
    public void ButtonDemo(string m){
        string s1 = UserName.text;
        if(string.IsNullOrEmpty(s1)){
            audioSource6.Play();
            Output.text = "Please Enter Your UserName !!";
        }
        else if(!booliii(s1)){
            audioSource7.Play();
            Output.text = "Your UserName is Undefined Please Make its Structure";
        }
        else{
            string filePath = "C:/GameTxtFiles/username.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(s1);
            }
            Output.text = "Finished";


            //
            string fileName22 = "C:\\GameTxtFiles\\user2.txt";
            WriteStringToFile(s1, fileName22);
            //




            Menu3();
        }
    }
    private bool booliii(string s1){
        string pattern = "\\b([0-9a-zA-Z]){10,15}\\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(s1);
    }
    public void Menu3(){
        SceneManager.LoadScene("Menu");
    }




    //
    void WriteStringToFile(string content, string fileName)
    {
        // مسیر کامل فایل
        string path = Path.Combine(Application.persistentDataPath, fileName);

        // نوشتن رشته در فایل
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.Write(content);
        }

        Debug.Log($"رشته در فایل {fileName} ذخیره شد: {path}");
    }
    //




}