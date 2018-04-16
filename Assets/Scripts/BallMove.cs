using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    [SerializeField]
    float speed;
    Animator animator;

	void Start () 
    {
        animator = this.GetComponent<Animator>();
	}

	void Update () 
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Wall" || collision.tag == "Block")
        {
            speed = -speed;
            if(speed < 0)
			    animator.SetInteger("flag", -1);
            else
                animator.SetInteger("flag", 1);
        }
	}
}