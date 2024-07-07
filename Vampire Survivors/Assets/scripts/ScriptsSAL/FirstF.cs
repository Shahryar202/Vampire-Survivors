using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Text.RegularExpressions;
using System.Collections;
public class FirstF : MonoBehaviour
{
    public TMP_InputField Email;
    public TextMeshProUGUI Output;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public void ButtonDemo()
    {
        string s1 = Email.text;
        if (string.IsNullOrEmpty(s1))
        {
            audioSource1.Play();
            Output.text = "Please Enter Your Email !!";
        }
        else if (!booli(s1))
        {
            audioSource2.Play();
            Output.text = "Your Email is Undefined Please Make its Structure";
        }
        else
        {
            string filePath = "C:/GameTxtFiles/emails.txt";
            string filePath2 = "C:/GameTxtFiles/loop.txt";
            string[] emails = File.ReadAllLines(filePath);
            bool foundMatch = false;
            foreach (string email in emails)
            {
                if (s1.Equals(email))
                {
                    Output.text = "You Before Signed Up Wait A Little More To Go To Log In";
                    using (StreamWriter writer = new StreamWriter(filePath2))
                    {
                        writer.WriteLine(s1);
                    }
                    audioSource3.Play();
                    StartCoroutine(DelayBeforeMoving());
                    foundMatch = true;
                    break;
                }
            }
            if (!foundMatch)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(s1);
                }
                transform.position = transform.position + new Vector3(-Screen.width, 0, 0);
            }
        }
    }

    private IEnumerator DelayBeforeMoving()
    {
        yield return new WaitForSeconds(10);
        transform.position = transform.position + new Vector3(+3 * Screen.width, 0, 0);
    }

    private bool booli(string s1)
    {
        string pattern = "\\b([0-9a-zA-Z]){25,35}@gmail\\.com\\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(s1);
    }
}
