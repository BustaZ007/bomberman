using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeScript : MonoBehaviour {

    Text  timeText;
    float time;
	void Awake () 
    {
        timeText = GetComponent<Text>();
        time = 120f;
	}
	void Update ()
    {
        if( time > 0)
        {
			timeText.text = "TIME:  " + (int)time;
			time-= Time.deltaTime;
        }
        else
            timeText.text = "TIME:  " + 0;
	}
}
