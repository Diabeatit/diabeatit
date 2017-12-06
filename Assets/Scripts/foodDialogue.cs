using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodDialogue : MonoBehaviour {

//	GameObject target;
	Text bubble;
	string txt;
	bool display;
	quickDialogue q;

	// Initialize dialogue count and first message
	void Start () {
//		q = new quickDialogue ();
		txt = "Banana!";
//		target = quickDialogue.target;
		bubble = quickDialogue.bubble;
	}

	void OnMouseDown() {
		quickDialogue.display = true;
		bubble.text = txt;
	}
//	// Display message based on dialogue
//	void Update () {
//		if (Input.GetMouseButtonDown (0)) {
//			if (display) {
//				target.SetActive (false);
//				display = false;
//			} 
//		}
//
//	}
}
