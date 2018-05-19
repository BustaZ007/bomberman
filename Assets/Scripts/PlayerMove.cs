using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public int MaxBombs;
    Animator animator;
    public GameObject Bombs;
    int count = 1;
	Dictionary<string, int> Items = new Dictionary<string, int>();
    public static int FireLenght;
	AudioSource Audio;
	public AudioClip UpFireSound;
	public AudioClip UpSpeedSound;
	public AudioClip DieSound;

	void Start()
	{
		Audio = GetComponent<AudioSource>();
		animator = gameObject.GetComponent<Animator>();
        FireLenght = 2;
		Items.Add("UpFire", 0);
		Items.Add("UpSpeed", 0);
		Items.Add("UpBombCount", 0);
	}
	void Update()
	{
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Bombs && count <= MaxBombs)
            {
                count++;
                Instantiate(Bombs, new Vector2(Mathf.RoundToInt(transform.position.x),
                                              Mathf.RoundToInt(transform.position.y)),
                                              Bombs.transform.rotation);
                Invoke("FectBoom", 2.0f);
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
			Audio.PlayOneShot(DieSound, 0.7f);
			Speed = 0;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            animator.SetBool("Die", true);
			Invoke("GameOver", 2.0f);
            Invoke("Die", 1.0f);
        }
        if (collision.tag == "Monster")
        {
			Audio.PlayOneShot(DieSound, 0.7f);
			Speed = 0;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            animator.SetBool("Die", true);
            Invoke("GameOver", 2.0f);
            Invoke("Die", 1.0f);
        }
		if (collision.tag == "UpFire")
		{
			if(Items["UpFire"] == 0)
			{
				FireLenght++;
                Audio.PlayOneShot(UpFireSound);
				Items["UpFire"]++;
			}
		}
		if (collision.tag == "UpSpeed")
        {
			if (Items["UpSpeed"] == 0)
            {
				Speed++;
				Audio.PlayOneShot(UpSpeedSound);
                Items["UpSpeed"]++;
            }
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
		{
			animator.SetInteger("DirectionX", 0);
        }
        
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
		{
			animator.SetInteger("DirectionY", 0);
        }
    }
}