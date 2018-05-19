using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    
    public GameObject FireCenter;
    public GameObject FireCryUp;
    public GameObject FireUpDown;
    public GameObject FireCryDown;
    public GameObject FireLeftRight;
    public GameObject FireCryLeft;
    public GameObject FireCryRight;
	AudioSource Audio;
	public AudioClip MakeBomb;
	public AudioClip BOOM;
	void Start ()
    {
		Audio = GetComponent<AudioSource>();
		Audio.PlayOneShot(MakeBomb);
        Invoke("WakeUp", .5f);
        Invoke("Boom", 2.0f);
	}
    void Boom()
    {
		Audio.PlayOneShot(BOOM,0.7f);
        Instantiate(FireCenter,new Vector2(transform.position.x, transform.position.y),
                    FireCenter.transform.rotation);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        MakeFire(FireCryUp, FireUpDown, Vector3.up);
        MakeFire(FireCryDown, FireUpDown, Vector3.down);
        MakeFire(FireCryLeft, FireLeftRight, Vector3.left);
        MakeFire(FireCryRight, FireLeftRight, Vector3.right);
        Destroy(gameObject, 1.2f);
    }

    void MakeFire(GameObject fire1, GameObject fire2, Vector3 vector)
    {
        for (int i = 1; i < PlayerMove.FireLenght; i++)
        {

            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position +
                                                            vector * i, 0.2f);
            if(col.Length == 0 && i == (PlayerMove.FireLenght - 1))
            {
                Instantiate(fire1, transform.position + vector * i,
                            fire1.transform.rotation);
                break;
            }
			if (col.Length == 0 || col[0].tag == "Player")
			{
				Instantiate(fire2, transform.position + vector * i,
				            fire2.transform.rotation);
				continue;
			}
            if (col[0].tag == "Wall" || col[0].tag == "Monster")
            {
                Instantiate(fire1, transform.position + vector * i,
                            fire1.transform.rotation);
                break;
            }
            if(col[0].tag == "Door")
            {
                Instantiate(fire2, transform.position + vector * i,
                            fire2.transform.rotation);
                continue;
            }
            if (col[0].tag == "Block")
                break;
        }
    }
    void WakeUp()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
