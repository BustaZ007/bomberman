using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	static bool move = true;
	static int count = 0;
	static void Update()
	{
		count++;
	}
    public static void Move(GameObject gameObject, float speed)
    {
        Collider2D[] colLeft = Physics2D.OverlapCircleAll(gameObject.transform.position -
                                                          gameObject.transform.right, 0.487f);
        Collider2D[] colRight = Physics2D.OverlapCircleAll(gameObject.transform.position +
		                                                   gameObject.transform.right, 0.487f);
        Collider2D[] colUp = Physics2D.OverlapCircleAll(gameObject.transform.position + 
		                                                gameObject.transform.up, 0.487f);
        Collider2D[] colDown = Physics2D.OverlapCircleAll(gameObject.transform.position - 
		                                                  gameObject.transform.up, 0.487f);

		if (move)
            if (colUp.Length == 0 || colDown.Length == 0)
            {
                if (count == 4)
                {
				gameObject.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
				gameObject.transform.position = new Vector2(Mathf.RoundToInt(gameObject.transform.position.x),
				                                            gameObject.transform.position.y);
                    count = 0;
                    move = false;
                }
                else
                {
					Update();
				gameObject.transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
                }
            }
            else
			gameObject.transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
        else
            if (colLeft.Length == 0 || colRight.Length == 0)
        {
            if (count == 4)
            {
				gameObject.transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
				gameObject.transform.position = new Vector2(gameObject.transform.position.x,
				                                            Mathf.RoundToInt(gameObject.transform.position.y));
                count = 0;
                move = true;
            }
            else
            {
				Update();
				gameObject.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
            }
        }
        else
				gameObject.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
	}
}
