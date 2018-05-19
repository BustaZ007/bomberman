using UnityEngine;
using UnityEngine.SceneManagement;

namespace DoorScript
{
	
	public class DoorScript : MonoBehaviour
	{
		public AudioClip FindTheExitSound;
		AudioSource Audio;
		void Start()
		{
			Audio = GetComponent<AudioSource>();
		}
		void FixedUpdate()
		{
			if (GameObject.FindGameObjectsWithTag("Monster").Length == 0)
				Audio.clip = FindTheExitSound;
		}
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
}