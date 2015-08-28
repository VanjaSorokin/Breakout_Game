using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int MenuNumber = 1;
	public GameObject instOne;
	public GameObject instTwo;
	public GameObject instThree;


	void Update()
	{
		if(Application.loadedLevelName == "Instructions")
		{
			if(MenuNumber == 1)
			{
				instOne.SetActive(true);
				instTwo.SetActive(false);
				instThree.SetActive(false);
			}
			if(MenuNumber == 2)
			{
				instOne.SetActive(false);
				instTwo.SetActive(true);
				instThree.SetActive(false);
			}
			if(MenuNumber == 3)
			{
				instOne.SetActive(false);
				instTwo.SetActive(false);
				instThree.SetActive(true);
			}
			if(MenuNumber == 4)
			{
				instOne.SetActive(false);
				instTwo.SetActive(false);
				instThree.SetActive(false);
			}
		}
	}

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

	void NextMenu()
	{
		MenuNumber ++;
	}
}
