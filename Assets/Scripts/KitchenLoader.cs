using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenLoader : MonoBehaviour {
	public string levelToLoad;

	void OnMouseDown() {

		if (levelToLoad.Equals("home")) {
			SceneManager.LoadScene ("home");

			dialogue_home_intro.box.setDialogue (6);
			dialogue_home_intro.box.setIntro (false);
		} else {
			SceneManager.LoadScene (levelToLoad);
		}
	}
}

