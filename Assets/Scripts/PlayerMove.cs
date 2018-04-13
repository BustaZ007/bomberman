using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject bomb;

	private void Update()
	{
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(bomb)
            {
                Instantiate(bomb, new Vector2(Mathf.RoundToInt(transform.position.x),
                                              Mathf.RoundToInt(transform.position.y)),
                                              bomb.transform.rotation);
            }
        }
	}
	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime*speed, Space.Self);
            animator.SetInteger("DirectionX", -1);
        }
        else if (moveHorizontal > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            animator.SetInteger("DirectionX", 1);
        }
        else
            animator.SetInteger("DirectionX", 0);
        
        if (moveVertical < 0)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
            animator.SetInteger("DirectionY", -1);
        }
        else if (moveVertical > 0)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed, Space.Self);
            animator.SetInteger("DirectionY", 1);
        }
        else
            animator.SetInteger("DirectionY", 0);
    }
}