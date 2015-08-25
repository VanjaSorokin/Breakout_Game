using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float BallInitalVelocity = 600f;
	private Rigidbody rb;
	private bool BallInPlay;

	//Gets the balls rigid body
	void Awake () {

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
}
