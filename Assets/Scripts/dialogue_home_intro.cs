using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_home_intro : MonoBehaviour {

	public Text bubble;
	public int dialogue;

	// Initialize dialogue count and first message
	void Start () {
		dialogue = 1;
		bubble.text = "Welcome to my house! Feel free to explore it to learn how I live with diabetes.";
	}
	
	// Display message based on dialogue
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (dialogue == 1) {
				bubble.text = "Click on one of my body parts to learn how Diabetes affects my body.";
			}
			else if (dialogue == 2) {
				bubble.text = "Which is true about the heart and diabetes?";
			}
			else if (dialogue == 3) {
				bubble.text = "What should I eat and drink?";
			}
			else if (dialogue == 4) {
				bubble.text = "Juice is good but is there a better option?";
			}
			else if (dialogue == 5) {
				bubble.text = "Today is so beautiful! Let’s do something outside!";
			}
			dialogue++;
		}
			
	}
}
