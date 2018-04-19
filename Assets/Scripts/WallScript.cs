using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    // Use this for initialization
    Animator animator;
	void Start ()
    {
        animator = this.GetComponent<Animator>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            animator.SetInteger("WallDeath", 1);
            Destroy(gameObject, 0.85f);
        }
    }
	// Update is called once per frame
	void Update ()
    {
	}
}
