using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcanvas: MonoBehaviour {
	public GameObject mySecondCanvas;

	public void myFunction() {
		mySecondCanvas.SetActive (true);
	}

	public void OnClickButton(string choice) {
		if( choice == "continue") {
			mySecondCanvas.SetActive(false);
		}
	}
}
