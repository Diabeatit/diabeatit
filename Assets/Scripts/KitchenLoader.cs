using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenLoader : MonoBehaviour {
	public string levelToLoad;

	void OnMouseDown() {

<<<<<<< HEAD
		if (levelToLoad.Equals("home")) {
			SceneManager.LoadScene ("home");

			dialogue_home_intro.box.setDialogue (6);
			dialogue_home_intro.box.setIntro (false);
=======
		if (levelToLoad == "back") {
			SceneManager.LoadScene ("Kitchen");
>>>>>>> c6a3848f1488981cb515621dd80a060e88609643
		} else {
			SceneManager.LoadScene (levelToLoad);
		}
	}
}

