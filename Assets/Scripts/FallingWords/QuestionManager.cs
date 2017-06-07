using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {

	public static bool nextQ = true;
	public static bool gameOver = false;
	public static int score = 0;

	public GameObject textBox;
	public TextAsset textFile;
	public Text theText;
	public Text scores;
	public string[] questions;
	public bool[] trueResults;
	public bool[] falseResults;

	public static int currentQuestion = 0;
	public int endQuestion;
	 
	// Use this for initialization
	void Start () {
		if (textFile != null) {
			questions = (textFile.text.Split ('\n'));
			trueResults = new bool[] {true, false, false, true, false, false};
			falseResults = new bool[] {false, true, true, false, true, true};
		}

		if (endQuestion == 0) {
			endQuestion = questions.Length - 1;
		}
	}	

	void Update () {
		theText.text = questions [currentQuestion];
		scores.text = "Score: " + score;
		clickTrue.correctTrue = trueResults [currentQuestion];
		clickFalse.correctFalse = falseResults [currentQuestion];

		if (Input.GetKeyDown(KeyCode.Return)) {
			currentQuestion += 1;
			nextQ = true;
		}
	}
}
