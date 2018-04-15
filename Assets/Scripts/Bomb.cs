using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject player;
    private BoxCollider2D box;
	void Start ()
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Boom", 3.0f);
	}
    void Boom()
    {
        
    }
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (transform.position !=
           new Vector3(Mathf.RoundToInt(player.transform.position.x),
                       Mathf.RoundToInt(player.transform.position.y)))
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}
}
