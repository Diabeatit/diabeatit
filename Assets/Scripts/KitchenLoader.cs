using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenLoader : MonoBehaviour {
	public string levelToLoad;

	void OnMouseDown() {
		if (levelToLoad == "back") {
			SceneManager.LoadScene ("Kitchen");
		} else {
			SceneManager.LoadScene (levelToLoad);
		}
	}
}

