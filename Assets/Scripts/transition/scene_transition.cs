using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_transition : MonoBehaviour {
	public static string PreviousScene = "";

	public string sceneToLoad;

	void OnMouseDown(){

		if (sceneToLoad == "back") {
			if (PreviousScene == null)
				SceneManager.LoadScene ("home");
			SceneManager.LoadScene (PreviousScene);
		} else {
			PreviousScene = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene (sceneToLoad);
		}
	}
}