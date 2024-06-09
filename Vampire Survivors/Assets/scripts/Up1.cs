using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up1 : MonoBehaviour
{
    public float volumeChangeAmount = 0.1f;
    public AudioSource musicSource;
    public void OnClick(){
        IncreaseVolume1();
    }
    void IncreaseVolume1()
    {
        musicSource.volume = Mathf.Clamp01(musicSource.volume + volumeChangeAmount);
    }
}