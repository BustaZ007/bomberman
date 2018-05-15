using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static int CountMonsters = 4;
    void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag == "Player" && GameObject.FindGameObjectsWithTag("Monster").Length == 0)
            SceneManager.LoadScene("Level2");
    }
}