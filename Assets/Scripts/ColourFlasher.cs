using UnityEngine;
using System.Collections;

public class ColourFlasher : MonoBehaviour {

	public Color rainbows;

	// Use this for initialization
	void Start () {
		rainbows.a = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
		//these are changed seperatly, to fix a weird bug that was crashing the game.
		rainbows.r = Random.Range(0.0f,1.0f);
		rainbows.g = Random.Range(0.0f,1.0f);
		rainbows.b = Random.Range(0.0f,1.0f);
		gameObject.renderer.material.color = rainbows;
	}

	void Destroy(){
		StartCoroutine(Wait());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(0.1f);
		gameObject.SetActive(false);
	}
}
