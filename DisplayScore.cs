using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DisplayScore : MonoBehaviour {

    int highscore = PlayerPrefs.GetInt("HighScore");
    public int isHighScore = 0;
    //Recognize that the code is referring to the textx component thsi script is attached to
    void Start () {
        if (isHighScore == 2)
        {
            Text myText = GetComponent<Text>();
            if (ScoreKeeper.score > highscore)
            {
                highscore = ScoreKeeper.score;
                PlayerPrefs.SetInt("HighScore", highscore);
            }
            myText.text = ScoreKeeper.score.ToString();
        } else if(isHighScore == 1)
        {
            Text yourText = GetComponent<Text>();
            yourText.text = Convert.ToString(highscore);
        }
    //Set Score to 0
    ScoreKeeper.Reset();
	}
}
