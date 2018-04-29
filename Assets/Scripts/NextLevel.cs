using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public bool isReady = false;
    int level = 0;

    //void  OnTriggerEnter( Collider col)
    //{
    //    if (col.tag == "Player") isReady = true;
    //    level++;
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isReady) SceneManager.LoadScene("Level2");
    }


    void UpDate()
    {
        GameObject[] allGo = FindObjectsOfType<GameObject>();
        foreach (GameObject go in allGo)
        {
            if (go.CompareTag("Monster"))
                isReady = false;
            else isReady = true;   
        }
    }
}
