using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    [SerializeField]
    float speed;
    Animator animator;
    bool isBusy;
    public GameObject player;

	void Start () 
    {
        animator = this.GetComponent<Animator>();
	}

	void Update () 
    {
        
        Collider2D [] colUp = Physics2D.OverlapCircleAll(transform.position + transform.up , 0.2f);
        Collider2D[] colDown = Physics2D.OverlapCircleAll(transform.position - transform.up , 0.2f);
        if (colUp.Length > 0 && colDown.Length > 0 )
            transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
        else
            transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);

    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Wall" || collision.tag == "Block" || collision.tag == "Bomb")
        {
            speed = -speed;
            if(speed < 0)
			    animator.SetInteger("flag", -1);
            else
                animator.SetInteger("flag", 1);
        }
        if(collision.tag == "Fire")
        {
            animator.SetInteger("flag", 2);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            speed = 0;
            Destroy(gameObject, 1.0f);
        }
	}
}