using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton : MonoBehaviour {

	public Button pause;
    public Text text;

	void Start() {
        Button pb = pause.GetComponent<Button>();
        text = pause.GetComponentInChildren<Text>();
        pb.onClick.AddListener(OnClick);
	}

	void OnClick() {
		if (!gameDisplay.isPaused ()) {
            // change button text to resume and pause game
            text.text = "RESUME";
			gameDisplay.pauseGame ();
		} else {
			// change button text to pause and resume game
			gameDisplay.resumeGame ();
            text.text = "PAUSE";
		}
	}
}
