using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

	public int Highscore1;
	public int Highscore2;
	public int Highscore3;
	public int newHighscore;

	public Text First;
	public Text Second;
	public Text Third;

	//this has to happen in update as It won't update in the storehighscore function.....
	void Update(){
		First.text = ("1: " + PlayerPrefs.GetInt("highscore1"));
		Second.text = ("1: " + PlayerPrefs.GetInt("highscore2"));
		Third.text = ("1: " + PlayerPrefs.GetInt("highscore3"));
	}

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
		}
	if(newHighscore < Highscore1 && newHighscore > Highscore2)
		{
		PlayerPrefs.SetInt("highscore3",  PlayerPrefs.GetInt("highscore2"));
		PlayerPrefs.SetInt("highscore2", newHighscore);
		}
	if(newHighscore < Highscore2 && newHighscore > Highscore3)
		{
		PlayerPrefs.SetInt("highscore3", newHighscore);
			First.text = ("1: " + PlayerPrefs.GetInt("highscore1"));
			Second.text = ("1: " + PlayerPrefs.GetInt("highscore2"));
			Third.text = ("1: " + PlayerPrefs.GetInt("highscore3"));
		}
	}
}
