using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    public float volumeChangeAmount = 0.1f;
    public AudioSource musicSource;
    public void OnClick(){
        IncreaseVolume();
    }
    void IncreaseVolume()
    {
        musicSource.volume = Mathf.Clamp01(musicSource.volume + volumeChangeAmount);
    }
}
