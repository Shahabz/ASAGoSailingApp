﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Timer1 : MonoBehaviour {
	public static Timer1 s_instance;

  public float timeLeft;
  public bool pause;
  public bool timesUp;
  public float normTime;
  public Color[] colorsToLerp = new Color[2];
  public bool useMat;
	public Image timerRadialImage;

  private float totalTime;
  private float amtOfSeconds;

  private Text thisText;

	void Awake () {
		s_instance = this;
    
    thisText = GetComponent<Text>();
	}

	void Update () {
		if(pause || timesUp){ 
			thisText.text = ((int)(timeLeft)).ToString();
		}else{
			timeLeft = totalTime-Time.time;
			normTime = Mathf.Abs((float)(timeLeft/amtOfSeconds)-1);
			thisText.text = ((int)(timeLeft+1)).ToString();

			if( timerRadialImage != null )
				timerRadialImage.fillAmount = timeLeft/amtOfSeconds;

			if(timeLeft < 0f){
				timesUp = true;
			} 
		}
	}

	public void Reset(float amtOfTime){
	    totalTime = Time.time + amtOfTime;
	    amtOfSeconds = amtOfTime;
	    pause = false;
	    timesUp = false;
	}

  public void Pause(){
  	pause = true;
  }
  public void Unpause(){
  	pause = false;
  }
}
