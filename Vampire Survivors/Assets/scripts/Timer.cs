using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        int minutes = ((int)t/60);
        int seconds = ((int)t%60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
