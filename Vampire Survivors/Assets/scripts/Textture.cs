using UnityEngine;
using TMPro;

public class Textture : MonoBehaviour
{
    public string[] texts = {
        "Hi Guys It is Us",
        "Daniel, ALi, Shahriar",
        "I Start With My Self",
        "I Am Daniel Interested In",
        "Creating Game And Artifical Intenlligence",
        "So The Person On The Left is Ali",
        "Ali is A Programmer And Hacker",
        "the Person On the Right is Shahriar",
        "He Is Interested in Making Mobile Application",
        "We Made This Game For You to Enjoy A Lot",
        "We Get Glad If You Support Us",
        "This Is My Telegram Id @Daniel123",
        "For Your Project Just Send Message To Me",
        "And We Do Our Best To help You",
        "Thank You"
    };

    public float changeInterval = 1f;
    public TextMeshProUGUI textField;
    private int currentIndex = 0;
    private float timer = 0f;
    private bool showTextsInOrder = false;

    void Start()
    {
        ShowTextsInOrder();
    }

    void ShowTextsInOrder()
    {
        currentIndex = 0;
        textField.text = texts[currentIndex];
        showTextsInOrder = true;
        timer = 0f;
    }

    void Update()
    {
        if (showTextsInOrder)
        {
            timer += Time.deltaTime;
            if (timer >= changeInterval)
            {
                timer = 0f;
                ChangeText();
            }
        }
    }

    void ChangeText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        textField.text = texts[currentIndex];
        if (currentIndex == texts.Length - 1)
            showTextsInOrder = false;
    }

    public void RestartTextDisplay()
    {
        ShowTextsInOrder();
    }
}
