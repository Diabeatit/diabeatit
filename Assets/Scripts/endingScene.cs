using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endingScene : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	bool zachWalk;
	bool zachSpeak;
	bool zachSleep;
	private Transform t;
	public Transform speaking;
	public Transform sleeping;

	// dialogue objects
	public GameObject dialogue;
	public Text dialogue_text;
	private int dialogue_count = 1;

	// dream bubble objects
	public GameObject dreamBubble;
	public Text dream_text;
	private int dream_count = 1;

	void Start () {
		// assign player object
		player = GameObject.FindGameObjectWithTag("Player");
		// rigidBody component to control velocity of player object
		rb = player.gameObject.GetComponent<Rigidbody2D> ();
		// transform component to get position of player object
		t = this.gameObject.GetComponent<Transform> ();

		// hide other Zach sprite objects
		speaking.transform.position = new Vector3(1, -0.69f, 2);
		sleeping.transform.position = new Vector3(1.02f, -0.33f, 2);

		// flags
		zachWalk = true;
		zachSpeak = false;

		// hide dialogue and dream bubble
		dialogue.SetActive(false);
		dreamBubble.SetActive(false);
	}
	
	void Update () {
		// Zach walks to bed
		if (transform.position.x < 1) {
			rb.velocity = new Vector2 (2, 0);
		} else {
			zachWalk = false;
			rb.velocity = new Vector2 (0, 0);
			t.transform.position = new Vector3(1, -0.69f, 2);
		}

		// Zach speaks before sleeping
		if (!zachWalk && !zachSpeak && !zachSleep) {
			speaking.transform.position = new Vector3(1, -0.69f, -2);
			dialogue.SetActive (true);
			zachSpeak = true;
			dialogue_text.text = "Thanks for hanging out with me today!";
		}

		if (zachSpeak) {
			if (Input.GetMouseButtonDown (0)) {
				if (dialogue_count == 1) {
					dialogue_text.text = "We learned a lot about Diabetes.";
				} else if (dialogue_count == 2) {
					dialogue_text.text = "I hope you'll remember everything we did today!";
				} else if (dialogue_count == 3) {
					dialogue_text.text = "The day has end and it's time to get a good night's sleep.";
				} else {
					dialogue.SetActive (false);
					zachSpeak = false;
					speaking.transform.position = new Vector3(1, -0.69f, 2);
					sleeping.transform.position = new Vector3(1.02f, -0.33f, -2);
					zachSleep = true;
					dreamBubble.SetActive (true);
				}
				dialogue_count++;
			}
		}
			
		// Zach dreams
		if (zachSleep) {
			if (Input.GetMouseButtonDown (0)) {
				if (dream_count == 1) {
					dream_text.text = "A Global Ties Project";
				} else if (dream_count == 2) {
					dream_text.text = "Brought to you by\n Diabeatit Spring 2017";
				} else if (dream_count == 3) {
					dream_text.text = "TA\nGabri Di Fiore";
				} else if (dream_count == 4) {
					dream_text.text = "Tech Team\n<size=20>Tyler Bakke - Chandler Blaid Burgess\nTyler Cuddy - Jeanette Phung\nGokul Suresh</size>";
				} else if (dream_count == 5) {
					dream_text.text = "UX Team\n<size=20>Kelsey Haag - Manali Kulkarni\nCrystal Jiao - Hunter Lai\nLucy Lopez - Anna June Park</size>";
				} else {
					dreamBubble.SetActive (false);
				}
				dream_count++;
			}
		}
	}
}
