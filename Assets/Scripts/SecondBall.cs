using UnityEngine;
using System.Collections;

public class SecondBall : MonoBehaviour {

	public float BallInitalVelocity = 600f;
	private Rigidbody rb;
	public AudioClip impact;
	AudioSource audio;
	private bool BallInPlay;
	public GameObject sprite;
	public Sprite Ball1;
	public Sprite Ball2;
	public TrailRenderer trail;
	
	//Gets the balls rigid body
	void Awake () {
		audio = GetComponent<AudioSource>();
		rb = GetComponent < Rigidbody > ();
		trail = gameObject.GetComponent<TrailRenderer>();
		trail.material.color = Color.blue;
	}
	
	//When you click it adds force and removes kinematic.
	void Update () 
	{
		if (BallInPlay == false) 
		{
			BallInPlay = true;
			rb.AddForce (new Vector3 (BallInitalVelocity, BallInitalVelocity, 0));
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		audio.PlayOneShot(impact, 0.7F);
		sprite.GetComponent<SpriteRenderer>().sprite = Ball2;
		trail.material.color = Color.red;
		//sprite.gameObject.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
		StartCoroutine(Wait());
	}
	
	IEnumerator Wait(){
		yield return new WaitForSeconds(0.05f);
		sprite.GetComponent<SpriteRenderer>().sprite = Ball1;
		trail.material.color = Color.blue;
		//	sprite.gameObject.transform.localScale = new Vector3(1,1,1);
	}
}
