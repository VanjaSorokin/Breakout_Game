using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject slime;
	public GameObject cloneSlime;
	public float SlimeInitalVelocity = -600f;

	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(Random.Range (0f, 20f));
		cloneSlime = Instantiate (slime, transform.position, Quaternion.identity) as GameObject;
		cloneSlime.rigidbody.AddForce (new Vector3 (0, SlimeInitalVelocity, 0));
	}
}
