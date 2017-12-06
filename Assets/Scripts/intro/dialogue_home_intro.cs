using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_home_intro : MonoBehaviour {
	public static dialogue_home_intro box;

	public GameObject target;
	public Text bubble;
	private int dialogue = 0;
	public static bool intro = true;

	// Initialize dialogue count and first message
	// intro flag to prevent intro dialogue from appearing more than once
	void Start () {
		box = this;

		if (intro) {
			box.dialogue = 1;
			bubble.text = "Welcome to my house! Feel free to explore it to learn how I live with diabetes.";
		} else {
			target.SetActive (false);
		}
	}

	// Set the Dialogue
	public void setDialogue (int value) {
		box.dialogue = value;
	}

	// Set the Intro boolean
	public void setIntro (bool boolean) {
		intro = boolean;
	}
	
	// Display message based on dialogue and disappear when finished
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (dialogue == 1) {
				bubble.text = "Click on one of my body parts to learn how Diabetes affects my body.";
			} else if (dialogue == 2) {
				bubble.text = "Which is true about the heart and diabetes?";
			} else if (dialogue == 3) {
				bubble.text = "What should I eat and drink?";
			} else if (dialogue == 4) {
				bubble.text = "Juice is good but is there a better option?";
			} else if (dialogue == 5) {
				bubble.text = "Today is so beautiful! Let’s do something outside!";
			} else if (box.dialogue == 6) {
				bubble.text = "What's next?";
			} else {
				target.SetActive (false);
			}
			intro = false;
			dialogue++;
		}
			
	}
}
