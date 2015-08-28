using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	public int BrickHP;
	public AudioClip impact;
	AudioSource audio;
	public GameObject Sprite1;
	public GameObject Sprite2;
	public GameObject Sprite3;
	public GameObject Sprite4;



	//When a brick is destoryed, it plays it's particle effect.
	//It will also play a sound when implemented.
	public GameObject BrickParticle;

	void Start() {
		audio = GetComponent<AudioSource>();
		SpriteDisplay();
	}


	void Update ()
	{
		if (BrickHP == 0) 
		{
			Instantiate (BrickParticle, transform.position, Quaternion.identity);
			GM.Instance.DestroyBrick ();
			Destroy (gameObject);
		}
	}

	void OnCollisionExit(Collision other)
	{
		Instantiate (BrickParticle, transform.position, Quaternion.identity);
		audio.PlayOneShot(impact, 0.7F);
		//print ("hit");
		Camera.main.SendMessage("Shake");
		GM.Instance.AddPoints(BrickHP*10);
		BrickHP -= 1;
		SpriteDisplay();
	}

	//This section changes what sprite the enemies show, as they take damage they change.
	void SpriteDisplay()
	{
		if(BrickHP == 4)
		{
			Sprite1.gameObject.SetActive(false);
			Sprite2.gameObject.SetActive(false);
			Sprite3.gameObject.SetActive(false);
			Sprite4.gameObject.SetActive(true);
		}
		if(BrickHP == 3)
		{
			Sprite1.gameObject.SetActive(false);
			Sprite2.gameObject.SetActive(false);
			Sprite3.gameObject.SetActive(true);
			Sprite4.gameObject.SetActive(false);
		}
		if(BrickHP == 2)
		{
			Sprite1.gameObject.SetActive(false);
			Sprite2.gameObject.SetActive(true);
			Sprite3.gameObject.SetActive(false);
			Sprite4.gameObject.SetActive(false);
		}
		if(BrickHP == 1)
		{
			Sprite1.gameObject.SetActive(true);
			Sprite2.gameObject.SetActive(false);
			Sprite3.gameObject.SetActive(false);
			Sprite4.gameObject.SetActive(false);
		}
	}
}
