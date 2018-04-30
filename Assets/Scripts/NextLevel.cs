using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static int ContMonsters = 1;
    int level = 0;


    //void  OnTriggerEnter( Collider col)
    //{
    //    if (col.tag == "Player") isReady = true;
    //    level++;
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ContMonsters == 0)
            SceneManager.LoadScene("Level2");
    }


    void UpDate()
    {
    }
}
