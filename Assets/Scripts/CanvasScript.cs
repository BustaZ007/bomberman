using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public Text TimeText;
    public Text ScoreText;
	private float time;
	private int score;
	void Start ()
	{
		score = 0;
		UpdateScore();
		time = 90f;
	}

	void Update () 
	{
		if (time > 0)
        {
            TimeText.text = "TIME:  " + (int)time;
            time -= Time.deltaTime;
        }
        else
            TimeText.text = "TIME:  " + 0;
		
	}
    void UpdateScore()
	{
		ScoreText.text = "SCORE: " + score;
	}
	public void AddScore(int scoreValue)
	{
		score += scoreValue;
		UpdateScore();
	}
}
