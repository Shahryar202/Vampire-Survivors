using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
   private float dddd;
   private bool titi = false;
   [SerializeField] TextMeshProUGUI Timerr;
   public void ti(){
    titi = true;
    dddd = 0f;
   }
   public void to(){
    titi = false;
    dddd = 0f;
   }
   void Update(){
    if(titi){
            dddd = dddd + Time.deltaTime;
            int minutes = Mathf.FloorToInt(dddd/60);
            int seconds = Mathf.FloorToInt(dddd%60);
            Timerr.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
   }
}

