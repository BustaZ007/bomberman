using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision)
    {
        int levelCount = 1;
        if (collision.tag == "Player" && GameObject.FindGameObjectsWithTag("Monster").Length == 0)
        {
            levelCount++;
            SceneManager.LoadScene("Level" + levelCount.ToString());
           
        }
            
    }
}
