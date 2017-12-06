using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public Text score; //reference to the ScoreText gameobject, set in editor
//	public AudioClip basket; //reference to the basket sound

	void OnCollisionEnter() //if ball hits board
	{
//		GetComponent<AudioSource>().Play(); //plays the hit board sound
	}

	void OnTriggerEnter() {
		float currentScore = float.Parse(score.text) + 0.5f; //add 1 to the score
		score.text = currentScore.ToString();
//		AudioSource.PlayClipAtPoint(basket, transform.position); //play basket sound
	}
}
