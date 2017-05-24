using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour {
	public GameObject ball; //reference to the ball prefab, set in editor
	private Vector3 throwSpeed = new Vector3(0, 12, 5); //This value is a sure basket, we'll modify this using the forcemeter
	public Vector3 ballPos; //starting ball position
	private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
	private GameObject ballClone; //we don't use the original prefab

	public Text availableShotsGO; //ScoreText game object reference
	private int availableShots = 10;

	public GameObject meter; //references to the force meter
	public GameObject arrow;
	private float arrowSpeed = 0.01f; //Difficulty, higher value = faster arrow movement
	private bool right = true; //used to revers arrow movement

	public Text gameOver; //game over text

	// Use this for initialization
	void Start () {
		/* Increase Gravity */
		Physics.gravity = new Vector3(0, -10, 3.66f);
		gameOver.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
//		int elapse = 0;

		/* Move Meter Arrow */

		if (arrow.transform.position.x < 2.5f && right)
		{
			arrow.transform.position += new Vector3(arrowSpeed, 0, 0);
		}
		if (arrow.transform.position.x >= 2.5f)
		{
			right = false;
		}
		if (right == false)
		{
			arrow.transform.position -= new Vector3(arrowSpeed, 0, 0);
		}
		if ( arrow.transform.position.x <= -2.5f)
		{
			right = true;
		}

		/* Shoot ball on Tap */

		if (Input.GetButton("Fire1") && !thrown && availableShots > 0)
		{
			thrown = true;
			availableShots--;
			availableShotsGO.text = availableShots.ToString();

			ballClone = Instantiate(ball, ballPos, transform.rotation) as GameObject;
			throwSpeed.y = throwSpeed.y + arrow.transform.position.x;
			throwSpeed.z = throwSpeed.z + arrow.transform.position.x;
			ball.SetActive (false);

//			elapse = System.DateTime.Now.Second;
			ballClone.GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
//			GetComponent<AudioSource>().Play(); //play shoot sound
		}

//		if (thrown) {
//			elapse = System.DateTime.Now.Second - elapse;
//		}

		/* Remove Ball when it hits the floor */

		if (ballClone != null && ballClone.transform.position.y < -2)// || elapse > 50)
		{
			Destroy(ballClone);
			ball.SetActive (true);
			thrown = false;
			throwSpeed = new Vector3(0, 15, 5);//Reset perfect shot variable
//			elapse = 0;

			/* Check if out of shots */
			if (availableShots == 0)
			{
				arrow.SetActive(false);
//				Instantiate(gameOver, new Vector3(0.31f, 0.2f, 0), transform.rotation);
				gameOver.gameObject.SetActive(true); 
				Invoke("restart", 2);
			}
		}
	}

	void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
