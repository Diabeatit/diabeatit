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

	void OnTriggerEnter() //if ball hits basket collider
	{
		int currentScore = int.Parse(score.text) + 1; //add 1 to the score
		score.text = currentScore.ToString();
//		AudioSource.PlayClipAtPoint(basket, transform.position); //play basket sound
	}
}
