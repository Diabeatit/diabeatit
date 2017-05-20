using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {

	public GameObject textBox;
	public TextAsset textFile;
	public Text theText;
	public string[] questions;

	public int currentQuestion;
	public int endQuestion;
	 
	// Use this for initialization
	void Start () {
		if (textFile != null) {
			questions = (textFile.text.Split ('\n'));
		}

		if (endQuestion == 0) {
			endQuestion = questions.Length - 1;
		}
	}	

	void Update () {
		theText.text = questions [currentQuestion];
	}
}
