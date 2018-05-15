using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    Text  timeText;
    float time;
	void Awake () 
    {
        timeText = GetComponent<Text>();
        time = 60f;
	}
	void Update ()
    {
        if( time > 0)
        {
			timeText.text = "TIME:  " + NextLevel.CountMonsters;
			time-= Time.deltaTime;
        }
        else
            timeText.text = "TIME:  " + 0;
	}
}
