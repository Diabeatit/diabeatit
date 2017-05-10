using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quickDialogue : MonoBehaviour {

	public GameObject target;
	public Text bubble;
	public string txt;
	public bool display;

	// Initialize dialogue count and first message
	void Start () {
		if (display) {
			bubble.text = txt;
		} else {
			target.SetActive (false);
			bubble.text = txt;
		}
	}

	// Display message based on dialogue
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (!display) {
				target.SetActive (true);
				display = true;
			} else {
				target.SetActive (false);
				display = false;
			}
		}

	}
}
