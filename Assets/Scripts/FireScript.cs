using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

	void Start ()
    {
        Invoke("OffDamage", 0.7f);
        Invoke("Destroing", 1.0f);
	}
    void OffDamage()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false; 
    }
	void Destroing()
	{
        Destroy(gameObject);
	}
	void Update ()
    {
		
	}
}
