using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	public int BrickHP;
	public AudioClip impact;
	AudioSource audio;

	//When a brick is destoryed, it plays it's particle effect.
	//It will also play a sound when implemented.
	public GameObject BrickParticle;

	void Start() {
		audio = GetComponent<AudioSource>();
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
		print ("hit");
		Camera.main.SendMessage("Shake");
		GM.Instance.AddPoints(BrickHP*10);
		BrickHP -= 1;
	}
}
