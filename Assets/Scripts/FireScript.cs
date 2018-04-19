using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

	void Start () {
        Invoke("OffDamage", 0.7f);
        Invoke("Destroing", 1.0f);
	}
    void OffDamage()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false; 
    }
	private void Destroing()
	{
        Destroy(gameObject);
	}

    void Die()
    {
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster" || collision.tag == "Wall")
            Invoke("Die", 0.2f);
	}
	void Update ()
    {
		
	}
}
