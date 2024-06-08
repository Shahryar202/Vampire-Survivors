using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Low : MonoBehaviour
{
    public float volumeChangeAmount = 0.1f;
    public AudioSource musicSource;
    public void OnClick(){
        DecreaseVolume();
    }
    void DecreaseVolume()
    {
        musicSource.volume = Mathf.Clamp01(musicSource.volume - volumeChangeAmount);
    }
}
