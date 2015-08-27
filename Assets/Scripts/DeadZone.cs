using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	//When the ball hits the trigger collider, you lose a life and 
	//it resets the paddle and ball to it's kinematic state.
	void OnTriggerEnter (Collider col)
	{
		GM.Instance.LoseLife ();
		Destroy(col.gameObject);
		Debug.Log ("Is working");
	}
}
