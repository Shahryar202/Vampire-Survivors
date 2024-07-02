using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Thrailer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    void Start(){
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp){
        startUI();
    }
    void startUI(){
        SceneManager.LoadScene("SAL");
    }
}
