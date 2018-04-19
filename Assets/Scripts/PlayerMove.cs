using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public int MaxBombs;
    [SerializeField]
    Animator animator;
    public GameObject Bomb;
    int count = 1;
	private void Update()
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Destroy(gameObject, 1.0f);
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