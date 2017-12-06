using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickFalse : MonoBehaviour {

	public static bool correctFalse = false;

	void OnMouseDown() {
		if (correctFalse == true) {
			QuestionManager.score += 1;
			Debug.Log (QuestionManager.score);
		}
		QuestionManager.currentQuestion += 1;
		QuestionManager.nextQ = true;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
