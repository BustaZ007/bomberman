using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    Animator animator;
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            animator.SetInteger("WallDeath", 1);
            Destroy(gameObject, 0.85f);
        }
    }
}
