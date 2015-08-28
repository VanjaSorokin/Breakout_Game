using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	public AudioClip impact;
	AudioSource audio;

	public GameObject MySprite;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Ball"){
			audio.PlayOneShot(impact, 0.7F);
			MySprite.SetActive(true);
			StartCoroutine(Wait());
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(0.05f);
		MySprite.SetActive(false);
	}
}
