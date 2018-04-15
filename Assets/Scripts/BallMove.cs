using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    [SerializeField]
    public float speed;
    [SerializeField]
    private Animator animator;
    private bool flag;
	// Use this for initialization
	void Start () 
    {
        flag = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Wall" || collision.tag == "Block")
        {
			speed = -speed;
			//flip();
        }
	}
    void flip()
    {
        animator.GetBool("false");
    }
}