using UnityEngine;
using System.Collections;

public class PopUpMultiplier : MonoBehaviour {



	//THIS SCRIPT IS WIP. DOES NOT WORK! I BLAME THE STUPID CANVAS.
	public GameObject ScoreText;
	public Camera mainCam;
	public Canvas canvas;

	private GameObject CloneText;

	void Start()
	{
		mainCam = Camera.main;
		PopUp();
	}

	void PopUp(){

		Vector3 pos = transform.position;

		pos.y = pos.y * 100;
		pos.x = pos.x * 100;
		
		CloneText = Instantiate (ScoreText, pos, Quaternion.identity) as GameObject;
		CloneText.transform.parent = canvas.transform;
	}
}
