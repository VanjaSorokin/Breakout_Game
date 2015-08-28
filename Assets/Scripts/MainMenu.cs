using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void StartGame()
	{
		Application.LoadLevel("Instructions");
	}

	void Quit()
	{
		Application.Quit();
	}

	void LoadMainScene()
	{
		Application.LoadLevel("MainGameScene");
	}
}
