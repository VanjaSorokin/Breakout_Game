using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	//These are all the game objects.
	public GameObject GameOver;
	public GameObject YouWon;
	public GameObject BricksPrefab;
	public GameObject Paddle;
	public GameObject DeathParticles;
	
	public int Lives = 3;
	public int Bricks = 20;
	public float ResetDelay = 1f;
	public Text LivesText;
	public static GM Instance = null;
	public bool YouWonTrue = false;
	
	//Created "YouWonTrue" becuase there was a bug where 
	//I could both win and lose the game at the same time. 
	
	private GameObject ClonePaddle;
	
	// Use this for initialization.
	void Start () 
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
		
		Setup ();
		
	}
	public void Setup()
	{
		ClonePaddle = Instantiate (Paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (BricksPrefab, transform.position, Quaternion.identity);
	}
	
	//This tells the player whether they have won or lost.
	void CheckGameOver()
	{
		if (Bricks < 1) 
		{
			YouWon.SetActive (true);
			YouWonTrue = true;
			Time.timeScale = .25f;
			Invoke ("Reset", ResetDelay);
		}
		
		if (Lives < 1 && YouWonTrue == false) 
		{
			GameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", ResetDelay);
		}
	}
	
	//This resets the application.
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}
	
	//This destroys the paddle and makes you lose a life when the ball enters the "DeadZone".
	public void LoseLife()
	{
		Lives --;
		LivesText.text = "Lives:" + Lives;
		Instantiate (DeathParticles, ClonePaddle.transform.position, Quaternion.identity);
		Destroy (ClonePaddle);
		Invoke ("SetUpPaddle", ResetDelay);
		CheckGameOver ();
	}
	
	//Spawns Paddle and ball.
	void SetUpPaddle()
	{
		ClonePaddle = Instantiate (Paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	//This says when a brick is destroyed, decrease the total number of bricks by 1.
	public void DestroyBrick()
	{
		Bricks --;
		CheckGameOver();
	}
}

