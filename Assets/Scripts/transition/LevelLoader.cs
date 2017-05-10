using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	public static string PreviousScene = "";

	public string levelToLoad;

	void OnMouseDown(){

		if (levelToLoad == "back") {
			if (PreviousScene == null)
				SceneManager.LoadScene ("main");
			SceneManager.LoadScene (PreviousScene);
		} else {
			PreviousScene = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene (levelToLoad);
		}
	}
}