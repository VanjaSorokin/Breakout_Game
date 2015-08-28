using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public GameObject[] Balls;

	void Update(){
		Balls = GameObject.FindGameObjectsWithTag("Ball");
	}

	//When the ball hits the trigger collider, you lose a life and 
	//it resets the paddle and ball to it's kinematic state.
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Ball" && Balls.Length >= 2)
		{
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag == "Ball" && Balls.Length == 1)
		{
			GM.Instance.LoseLife ();
			Destroy(col.gameObject);
			Debug.Log ("Is working");
		}
	}
}
