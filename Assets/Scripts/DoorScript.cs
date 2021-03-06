using UnityEngine;
using UnityEngine.SceneManagement;

namespace DoorScript
{
	
	public class DoorScript : MonoBehaviour
	{
		public AudioClip FindTheExitSound;
		AudioSource Audio;
		public int CurentLevel;
		public AudioClip FinishSound;
		int musicFlag;
		public GameObject monster;
		int Flag = 2;
		void Start()
		{
			Audio = GetComponent<AudioSource>();
			ReloadMusicFlag();
		}
		void ReloadMusicFlag()
		{
			musicFlag = 0;
			Invoke("ReloadMusicFlag", 70f);
		}
		void FixedUpdate()
		{
			if (GameObject.FindGameObjectsWithTag("Monster").Length == 0 && musicFlag == 0)
			{
				Audio.clip = FindTheExitSound;
				Audio.Play();
				musicFlag++;
            }
		}
		void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag == "Player" && GameObject.FindGameObjectsWithTag("Monster").Length == 0)
			{
				GameObject.FindWithTag("Player").GetComponent<PlayerMove>().Speed = 0;
				Audio.clip = FinishSound;
                Audio.Play();
				Invoke("LoadScene", 4.0f);
            }
			if(collision.tag == "Fire")
			{
				if (Flag <= 1)
					Invoke("MakeMonster", 1f);
				else
					Flag--;
			}
        }
		void MakeMonster()
		{
			Instantiate(monster, new Vector2(transform.position.x, transform.position.y),
			            monster.transform.rotation);
		}
        void LoadScene()
        {
			SceneManager.LoadScene("Stage" + (CurentLevel + 1).ToString());
		}
	}
}