using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour {

    [SerializeField]
    float speed;
    Animator animator;
    public GameObject player;
	CanvasScript score;
    bool move;
    int count = 0;
	public int scoreValue;
	int minScore;
	void Start () 
    {
		score = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
        animator = gameObject.GetComponent<Animator>();
        move = true;
		UpdateMinScore();
	}
	void UpdateMinScore()
	{
		minScore = 0;
		Invoke("UpdateMinScore", 0.5f);
	}
	void Update () 
    {
        Collider2D[] colLeft = Physics2D.OverlapCircleAll(transform.position - transform.right, 0.487f);
        Collider2D[] colRight = Physics2D.OverlapCircleAll(transform.position + transform.right, 0.487f);
        Collider2D [] colUp = Physics2D.OverlapCircleAll(transform.position + transform.up , 0.487f);
        Collider2D[] colDown = Physics2D.OverlapCircleAll(transform.position - transform.up , 0.487f);

        if(move)
            if (colUp.Length == 0 || colDown.Length == 0)
            {
                if(count == 4)
                {
    				transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
                    transform.position = new Vector2(Mathf.RoundToInt(transform.position.x),
                                                     transform.position.y);
                    count = 0;
                    move = false;
                }
                else
                {
    				count++;
    				transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
                }
            }
            else
                transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
        else
            if (colLeft.Length == 0 || colRight.Length == 0)
            {
                if (count == 4)
                {
                    transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
                    transform.position = new Vector2(transform.position.x,
                                                     Mathf.RoundToInt(transform.position.y));
                    count = 0;
                    move = true;
                }
                else
                {
    				count++;
    				transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
                }
            }
            else
                transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Wall" || collision.tag == "Block" ||
            collision.tag == "Bomb"  || collision.tag == "Monster")
        {
            speed = -speed;
			if (speed < 0)
				animator.SetInteger("flag", -1);
			else
				animator.SetInteger("flag", 1);
        }
        if(collision.tag == "Fire")
        {
			speed = 0;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
			BoxCollider2D[] myColliders = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D bc in myColliders)
				bc.enabled = false;
			if(minScore == 0)
			{
				score.AddScore(scoreValue);
				minScore++;        
            }
            animator.SetInteger("flag", 2);
            Destroy(gameObject, 4.01f);

        }
	}
}