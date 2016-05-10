using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour {


	//This loads the next level upon calling
	public void AdvanceLevel (string nextLevel) {
		SceneManager.LoadScene(nextLevel);
	}

	//Exit the game
	public void QuitOut() {
		Application.Quit();
	}

}
