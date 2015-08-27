using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

	public int oldHighscore;
	public int newHighscore;

	void StoreHighscore(int newHighscore)
 	{
    int oldHighscore = PlayerPrefs.GetInt("highscore", 0);   
	print (oldHighscore);

	if(newHighscore > oldHighscore)
         PlayerPrefs.SetInt("highscore", newHighscore);
	}
}
