using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    
    public GameObject FireCenter;
    public GameObject FireCryUp;
    public GameObject FireUp;
    public GameObject FireCryDown;
    public GameObject FireDown;
    public GameObject FireCryLeft;
    public GameObject FireCryRight;
    int g = 4;
	void Start ()
    {
        Invoke("WakeUp", .5f);
        Invoke("Boom", 2.0f);
	}
    void Boom()
    {
        Instantiate(FireCenter,new Vector2(transform.position.x, transform.position.y),
                    FireCenter.transform.rotation);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Collider2D[] colDown = Physics2D.OverlapCircleAll(transform.position - transform.up, 0.2f);
        Collider2D[] colLeft = Physics2D.OverlapCircleAll(transform.position - transform.right, 0.2f);
        Collider2D[] colRight = Physics2D.OverlapCircleAll(transform.position + transform.right, 0.2f);
        for (int i = 1; i < g; i++)
        {

            Collider2D[] colUp = Physics2D.OverlapCircleAll(transform.position +
                                                            new Vector3(0,i,0), 0.2f);
            if(colUp.Length == 0)
            {
				Instantiate(FireCryUp, new Vector2(transform.position.x,
				                                   transform.position.y + i),
				            FireCryUp.transform.rotation);
                continue;
            }
            if (colUp[0].tag == "Block")
                break;
            if (colUp[0].tag == "Wall" || colUp[0].tag == "Monster"|| i == g - 1)
            {
                Instantiate(FireCryUp,new Vector2(transform.position.x,
                                                  transform.position.y + i),
                            FireCryUp.transform.rotation);
                break;
            }
        }
        Destroy(gameObject, 0.3f);
    }
    void WakeUp()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
	// Update is called once per frame
	void Update ()
    {
	}
}
