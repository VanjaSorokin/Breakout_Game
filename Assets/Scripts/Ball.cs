using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float BallInitalVelocity = 600f;
	private Rigidbody rb;
	public AudioClip impact;
	AudioSource audio;
	private bool BallInPlay;
	public GameObject sprite;
	public Sprite Ball1;
	public Sprite Ball2;
	public TrailRenderer trail;
	public GameObject NewBall;
	public int SlowPower;
	public bool Slowing = false;

	public GameObject GM;
	public GM _gm;

	//Gets the balls rigid body
	void Awake () {
		audio = GetComponent<AudioSource>();
		rb = GetComponent < Rigidbody > ();
		trail = gameObject.GetComponent<TrailRenderer>();
		trail.material.color = Color.blue;
	}

	void Start()
	{
		GM = GameObject.FindGameObjectWithTag("GM");
		_gm = GM.GetComponent<GM>();
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
		sprite.GetComponent<SpriteRenderer>().sprite = Ball2;
		trail.material.color = Color.red;
		//sprite.gameObject.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
		StartCoroutine(Wait());
		if(_gm.CurrentScore >= 1000 && _gm.SecondBallUsed == false)
		{
			_gm.SecondBallUsed = true;
			Instantiate (NewBall, transform.position, Quaternion.identity);
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.05f);
		sprite.GetComponent<SpriteRenderer>().sprite = Ball1;
		trail.material.color = Color.blue;
	//	sprite.gameObject.transform.localScale = new Vector3(1,1,1);
	}
}
