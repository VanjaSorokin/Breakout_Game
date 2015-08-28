using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

	public int Highscore1;
	public int Highscore2;
	public int Highscore3;
	public int newHighscore;

	void StoreHighscore(int newHighscore)
 	{
    int Highscore1 = PlayerPrefs.GetInt("highscore1", 0); 
	int Highscore2 = PlayerPrefs.GetInt("highscore2", 0);   
	int Highscore3 = PlayerPrefs.GetInt("highscore3", 0);   

	if(newHighscore > Highscore1)
		{
		PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("highscore2"));
		PlayerPrefs.SetInt("highscore2",  PlayerPrefs.GetInt("highscore1"));
    	PlayerPrefs.SetInt("highscore1", newHighscore);

			print (PlayerPrefs.GetInt("highscore1"));
			print (PlayerPrefs.GetInt("highscore2"));
			print (PlayerPrefs.GetInt("highscore3"));
		}
	if(newHighscore < Highscore1 && newHighscore > Highscore2)
		{
		PlayerPrefs.SetInt("highscore3",  PlayerPrefs.GetInt("highscore2"));
		PlayerPrefs.SetInt("highscore2", newHighscore);

			print (PlayerPrefs.GetInt("highscore1"));
			print (PlayerPrefs.GetInt("highscore2"));
			print (PlayerPrefs.GetInt("highscore3"));
		}
	if(newHighscore < Highscore2 && newHighscore > Highscore3)
		{
			PlayerPrefs.SetInt("highscore3", newHighscore);

			print (PlayerPrefs.GetInt("highscore1"));
			print (PlayerPrefs.GetInt("highscore2"));
			print (PlayerPrefs.GetInt("highscore3"));
		}
	}
}
