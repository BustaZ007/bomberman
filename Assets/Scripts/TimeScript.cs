using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeScript : MonoBehaviour
{

    Text timeText;
    float time;
    public GameObject water;
    int count = 0;
    void Awake()
    {
        timeText = GetComponent<Text>();
        time = 120f;
    }
    void Update()
    {
        if (time > 0)
        {
            timeText.text = "TIME: " + (int)time;
            time -= Time.deltaTime;
        }
        else if (count == 0)
        {
            timeText.text = "TIME: " + 0;
            count++;
            Instantiate(water, new Vector2(1, 1), water.transform.rotation);
            Instantiate(water, new Vector2(1, 11), water.transform.rotation);
            Instantiate(water, new Vector2(13, 11), water.transform.rotation);
            Instantiate(water, new Vector2(13, 1), water.transform.rotation);
        }
        else
            timeText.text = "TIME: " + 0;
    }
}