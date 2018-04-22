using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
	void Update () 
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Level1");
        if (Input.GetKey(KeyCode.Space))
            SceneManager.LoadScene("Level1");
	}
}
