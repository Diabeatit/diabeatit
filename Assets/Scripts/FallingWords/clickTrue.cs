using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickTrue : MonoBehaviour {

	public static bool correctTrue = false;

	void OnMouseDown() {
		if (correctTrue == true) {
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
