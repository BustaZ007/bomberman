using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    
    public GameObject FireCenter;
    public GameObject FireCryUp;
    public GameObject FireUp;
    int g = 2;
	void Start ()
    {
        Invoke("WakeUp", 1.0f);
        Invoke("Boom", 3.0f);
	}
    void Boom()
    {
        Instantiate(FireCenter,new Vector2(transform.position.x, transform.position.y),
                    FireCenter.transform.rotation);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 1; i < g; i++)
        {
            var coll = Physics2D.OverlapPoint(transform.position + Vector3.up).tag;
            if (coll == "Block")
                break;
                
            if(i == g-1 || coll == "Wall")
            {
				Instantiate(FireCryUp, new Vector2(transform.position.x, transform.position.y + i),
				            FireCryUp.transform.rotation);
                break;
            }
            Instantiate(FireUp, new Vector2(transform.position.x, transform.position.y + i),
                            FireUp.transform.rotation);
        }
        Destroy(gameObject, 0.3f);
    }
    void WakeUp()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
	// Update is called once per frame
	void Update ()
    {
	}
}
