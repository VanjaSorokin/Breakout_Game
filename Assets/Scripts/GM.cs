using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	//These are all the game objects.
	public GameObject BricksPrefab;
	public GameObject Paddle;
	public GameObject DeathParticles;
	public GameObject ColourFlasher;

	public Canvas HighScore;
	public Canvas GameOver;
	public Canvas YouWon;
	public int CurrentScore;
	public int Lives = 3;
	public int Bricks = 20;
	public float ResetDelay = 1f;
	public Text LivesText;
	public Text ScoreText;
	public Text FinalScoreText1;
	public Text FinalScoreText2;
	public static GM Instance = null;
	public bool YouWonTrue = false;


	public int CurrentMultiplier;
	
	//Created "YouWonTrue" becuase there was a bug where 
	//I could both win and lose the game at the same time. 
	
	private GameObject ClonePaddle;

	public Canvas pauseCanvas;
	bool m_paused;
	
	// Use this for initialization.
	void Start () 
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
		
		Setup ();
		pauseCanvas.gameObject.SetActive(false);
	}

	void Update()
	{
		Pauser();
		ScoreText.text = "Score:" + CurrentScore;
		//had to put these in update, as they wouldn't change in the Win/Loss section.
		FinalScoreText1.text = "YOUR SCORE: " + CurrentScore;
		FinalScoreText2.text = "YOUR SCORE: " + CurrentScore;
	}

	public void Setup()
	{
		CurrentMultiplier = 1;
		CurrentScore = 0;
		ClonePaddle = Instantiate (Paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (BricksPrefab, transform.position, Quaternion.identity);
	}
	
	//Pause Funtcions
	void Pauser()
	{
		if(Input.GetKeyUp(KeyCode.Escape)){
			if(m_paused == false){
				pauseCanvas.gameObject.SetActive(true);
				Time.timeScale = 0;
				m_paused = true;
			}
		}
	}
	public void ReturnToMenu()
	{
		Application.LoadLevel("MainMenu");
	}
	public void Unpause(){
		Time.timeScale = 1;
		pauseCanvas.gameObject.SetActive(false);
		m_paused = false;
	}



	//This tells the player whether they have won or lost.
	void CheckGameOver()
	{
		if (Bricks < 1) 
		{
			CurrentScore += 1000; //Bonus points for WINNING!
			YouWon.gameObject.SetActive(true);
			YouWonTrue = true;
			Time.timeScale = .0f;
			//SET HIGHSCORE!
		}
		
		if (Lives < 1 && YouWonTrue == false) 
		{
			GameOver.gameObject.SetActive(true);
			Time.timeScale = .0f;
			//SET HIGHSCORE!
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

	//Adds Points Based on Multiplier
	public void AddPoints(int points)
	{
		CurrentMultiplier += 1;
		points = (points*CurrentMultiplier);
		CurrentScore = (CurrentScore + points);

		if(CurrentMultiplier >= 3)
		{
			ColourFlasher.SetActive(true);
			ColourFlasher.SendMessage("Destroy");
		}
	}

	//Resets Multiplier
	public void ResetMultiplier()
	{
		CurrentMultiplier = 1;
	}


}

