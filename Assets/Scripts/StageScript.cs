using UnityEngine.SceneManagement;
using UnityEngine;

public class StageScript : MonoBehaviour 
{
	public int CurentLevel;
	void Start()
    {
		Invoke("LoadScene", 1.8f);
    }
	void LoadScene()
    {
        SceneManager.LoadScene("Level" + (CurentLevel).ToString());
    }
}
