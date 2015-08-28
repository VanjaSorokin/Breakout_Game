using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public AudioClip impact;
	AudioSource audio;
	public float PaddleSpeed = 1f;

	private Vector3 PlayerPos = new Vector3 (0, -9.5f, 0);

	void Start() {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
		{
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * PaddleSpeed);
		PlayerPos = new Vector3 (Mathf.Clamp (xPos, -8f, 8f), -9.5f, 0f);
		transform.position = PlayerPos;
	}

	void OnCollisionEnter (Collision other)
	{
		audio.PlayOneShot(impact, 0.7F);
		GM.Instance.ResetMultiplier();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Slime")
		{
			PaddleSpeed = 0.1f;
			StartCoroutine(Wait());
			Destroy(col.gameObject);
			GM.Instance.SubtractPoints();
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(2f);
		PaddleSpeed = 1f;
	}
}