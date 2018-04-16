using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroing", 1.0f);
	}
	private void Destroing()
	{
        Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
