using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quickDialogue : MonoBehaviour {

	public static GameObject target;
	public static Text bubble;
//	public GameObject banana, cake, sweetPotato, broc;

//	List<GameObject> foodDict;
	private string txt;
	public static bool display;

	// Initialize dialogue count and first message
	void Start () {
		txt = "Help me decide what I should eat!";
		display = true;

//		foodDict = new List<GameObject> ();
//		foodDict.Add (banana);
//		foodDict.Add (cake);
//		foodDict.Add (sweetPotato);
//		foodDict.Add (broc);
//
		bubble.text = txt;
	}

	// Display message based on dialogue
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (display) {
				target.SetActive (false);
				display = false;
			} 
		}

	}
}
