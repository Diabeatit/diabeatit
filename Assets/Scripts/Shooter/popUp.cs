using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp : MonoBehaviour {
	// Attach this to main Canvas

	public GameObject transCanvas;
	private bool active = false;

	// Use this for initialization
	void Start () {
		// get references to canvases and deactivate them until needed
		transCanvas = GameObject.Find ("transCanvas");
		transCanvas.GetComponent<Canvas>().enabled = false;
		transCanvas = GameObject.Find ("transCanvas1");
		transCanvas.GetComponent<Canvas>().enabled = false;
		transCanvas = GameObject.Find ("transCanvas2");
		transCanvas.GetComponent<Canvas>().enabled = false;
		transCanvas = GameObject.Find ("transCanvas3");
		transCanvas.GetComponent<Canvas>().enabled = false;
	}

	// Call when paused to change the transition image and activate it
	public void displayTransition() {
		int level = gameDisplay.getLevel ();
		switch (level) {
		case 0:
			transCanvas = GameObject.Find ("transCanvas");
			break;
		case 1:
			transCanvas = GameObject.Find("transCanvas1");
			break;
		case 2:
			transCanvas = GameObject.Find("transCanvas2");
			break;
		case 3:
			transCanvas = GameObject.Find("transCanvas3");
			break;
		default:
			break;
		} 
		transCanvas = GameObject.Find ("transCanvas");
		transCanvas.GetComponent<Canvas>().enabled = true;
		transCanvas = GameObject.Find ("transCanvas1");
		transCanvas.GetComponent<Canvas>().enabled = true;
		transCanvas = GameObject.Find ("transCanvas2");
		transCanvas.GetComponent<Canvas>().enabled = true;
		transCanvas = GameObject.Find ("transCanvas3");
		transCanvas.GetComponent<Canvas>().enabled = true;
	}

	// Update is called once per frame
	void Update() {
		// Check for paused state
		if (!(gameDisplay.isPaused ())) {
			// Insert what to do when game is not paused here

		} else {
			// Insert what to do when game is paused here
			if (!active) {
				displayTransition();
				active = true;
			}
			// On screen touch
			if (Input.GetMouseButtonDown(0)) {
				// Resume game and deactivate canvas
				gameDisplay.resumeGame();
				active = false;
				transCanvas.SetActive (false);
			}
			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
}
