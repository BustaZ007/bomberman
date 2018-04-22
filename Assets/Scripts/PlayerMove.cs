using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public int MaxBombs;
    Animator animator;
    public GameObject Bomb;
    int count = 1;
	private void Start()
	{
        animator = gameObject.GetComponent<Animator>();
	}
	void Update()
	{
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Bomb && count <= MaxBombs)
            {
                count++;
                Instantiate(Bomb, new Vector2(Mathf.RoundToInt(transform.position.x),
                                              Mathf.RoundToInt(transform.position.y)),
                                              Bomb.transform.rotation);
                Invoke("FectBoom", 3.0f);
            }
        }
	}

    void FectBoom()
    {
        count--;
    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    void Die()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Speed = 0;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            animator.SetBool("Die", true);
			Invoke("GameOver", 2.0f);
            Invoke("Die", 1.0f);
        }
        if (collision.tag == "Monster")
        {
			Speed = 0;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            animator.SetBool("Die", true);
            Invoke("GameOver", 2.0f);
            Invoke("Die", 1.0f);
        }
    }
	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime*Speed, Space.Self);
            animator.SetInteger("DirectionX", -1);
        }
        else if (moveHorizontal > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
            animator.SetInteger("DirectionX", 1);
        }
        else
            animator.SetInteger("DirectionX", 0);
        
        if (moveVertical < 0)
        {
            transform.Translate(Vector2.down * Time.deltaTime * Speed, Space.Self);
            animator.SetInteger("DirectionY", -1);
        }
        else if (moveVertical > 0)
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed, Space.Self);
            animator.SetInteger("DirectionY", 1);
        }
        else
            animator.SetInteger("DirectionY", 0);
    }
}