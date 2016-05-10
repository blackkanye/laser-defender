using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    //obviously the score
	public static int score = 0;

	//set value for Text UI Object
	private Text myText;
	
	// Set the Text object's value to 0
	void Start () {
		myText = GetComponent<Text>();
		Reset();
	
	}


	//adds points to the score and then updates the Text
	public void Score(int points) {
		Debug.Log("Scored points");
		score += points;
		myText.text = score.ToString();
	
	}


	//reset the score to 0
	public static void Reset(){
		score = 0;
	}

}
