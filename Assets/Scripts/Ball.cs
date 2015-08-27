using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float BallInitalVelocity = 600f;
	private Rigidbody rb;
	public AudioClip impact;
	AudioSource audio;
	private bool BallInPlay;

	//Gets the balls rigid body
	void Awake () {
		audio = GetComponent<AudioSource>();
		rb = GetComponent < Rigidbody > ();

	}

	//When you click it adds force and removes kinematic.
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && BallInPlay == false) 
		{
			transform.parent = null;
			BallInPlay = true;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (BallInitalVelocity, BallInitalVelocity, 0));

		}
	}

	void OnCollisionEnter(Collision other)
	{
		audio.PlayOneShot(impact, 0.7F);
	}
}
