using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour 
{
	CanvasScript score;
    public int scoreValue;
    int minScore;
	private void Start()
	{
		score = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
		UpdateMinScore();
    }
    void UpdateMinScore()
    {
        minScore = 0;
        Invoke("UpdateMinScore", 0.5f);
    }
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
		{
			if (minScore == 0)
			{
				score.AddScore(scoreValue);
				minScore++;
            }
			Destroy(gameObject, 0.1f);
        }
    }
}