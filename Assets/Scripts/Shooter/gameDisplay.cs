using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameDisplay : MonoBehaviour {

	// Time variables for creating delays
	private float time = 1f;

	// Count of food consumed
	public static int count;

	// Pause flag
	public static bool paused = false;

	// Checkpoint flags
	public static bool introCheck = false;
	public static bool check1 = false;
	public static bool check2 = false;

	// Level tracker
	public static int level = 0;

	// Text objects
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
		count = 0; // Game always starts with score of 0
		setCountText(); // Displays score as 0
		winText.text = "";
	}

	// Reset static variables when game ends so they work on next load
	public static void Reset() {
		count = 0;
		level = 0;
		paused = false;
		introCheck = false;
		check1 = false;
		check2 = false;
	}

	// Update is called once per frame
	void Update () {
		// Check for paused state
		if (!gameDisplay.isPaused()) {
			setCountText ();
			checkProgress ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	// To be called in Update()
	// Sets the count text based on current count
	public void setCountText(){
		countText.text = "score: " + getCount();
	}

	// To be called in Update()
	// Checks current count to check for and handle win/transition condition
	public void checkProgress() {
		if ((count == 0) && (!introCheck)) {
			// Pause to show intro transition image before gameplay starts
			gameDisplay.pauseGame ();
            winText.text = "LEVEL1";
            introCheck = true;
		} else if ((count >= 500) && (!check1)) {
            level = 1;
            gameDisplay.pauseGame ();
            winText.text = "LEVEL2";
            check1 = true;
		} else if ((count >= 2000) && (!check2)) {
			level = 2;
			gameDisplay.pauseGame ();
			winText.text = "";
            winText.text = "LEVEL3";
            check2 = true; 
        } else if ((count >= 5000) && (characterHealth.currentHealth > 0)) {
			winText.text = "YOU WIN!!!";
			// Delay 3 seconds then load home scene
			//if (time > 0) {
			//	time -= Time.deltaTime;
			//} else {
				//Reset ();
				//SceneManager.LoadScene ("home"); 

            //}
        } else {

		}
	}
    // Update count with appropriate value based on food string parameter
	public static void updateDisplay(string food){
        // score doubling factor for being in green zone
        int factor  = 1;
        if (characterHealth.currentHealth <= 50f && characterHealth.currentHealth >= -50f) {
            factor = 2;
        }

        // Following items are based off of Food Table doc Winter 2019
        if (food == "appleJuice") {
            count += (factor * 62);
            characterHealth.TakeDamage(19f);
            Debug.Log("I took damage");
        }
        if (food == "bread") {
            count += (factor * 50);
            characterHealth.TakeDamage(15f);
            Debug.Log("I took damage");
        }
        if (food == "broccoli") {
            count += (factor * 50);
            characterHealth.TakeDamage(15f);
            Debug.Log("I took damage");
        }
        if (food == "cheese") {
            count += (factor * 50);
            characterHealth.TakeDamage(15f);
            Debug.Log("I took damage");
        }
        if (food == "cherry") {
            count += (factor * 46);
            characterHealth.TakeDamage(14f);
            Debug.Log("I took damage");
        }
        if (food == "chicken") {
            count += (factor * 37);
            characterHealth.TakeDamage(11f);
            Debug.Log("I took damage");
        }
        if (food == "cola") {
            count += (factor * 68);
            characterHealth.TakeDamage(20f);
            Debug.Log("I took damage");
        }
        if (food == "cupcake") {// No cupcake in google doc, values are from muffin
            count += (factor * 68);
            characterHealth.TakeDamage(20f);
            Debug.Log("I took damage");
        }
        if (food == "donut") {
            count += (factor * 74);
            characterHealth.TakeDamage(22f);
            Debug.Log("I took damage");
        }
        if (food == "fries") {
            count += (factor * 82);
            characterHealth.TakeDamage(25f);
            Debug.Log("I took damage");
        }
        if (food == "grapes") {
            count += (factor * 54);
            characterHealth.TakeDamage(16f);
            Debug.Log("I took damage");
        }
        if (food == "iceCream") {
            count += (factor * 58);
            characterHealth.TakeDamage(17f);
            Debug.Log("I took damage");
        }
        if (food == "milk") {
            count += (factor * 22);
            characterHealth.TakeDamage(7f);
            Debug.Log("I took damage");
        }
        if (food == "pancakes") {
            count += (factor * 100);
            characterHealth.TakeDamage(30f);
            Debug.Log("I took damage");
        }
        if (food == "pizza") {
            count += (factor * 50);
            characterHealth.TakeDamage(15f);
            Debug.Log("I took damage");
        }
        if (food == "water") {
            count += (factor * 20);
            characterHealth.TakeDamage(-6f);
            Debug.Log("I took damage");
        }
        if (food == "oneHrFifteenMin") {
            count += (factor * 25);
            characterHealth.TakeDamage(-8f);
            Debug.Log("I took damage");
        }
        if (food == "oneHrThirtyMin") {
            count += (factor * 50);
            characterHealth.TakeDamage(-15f);
            Debug.Log("I took damage");
        }
        if (food == "oneHrFourtyFiveMin") {
            count += (factor * 75);
            characterHealth.TakeDamage(-23f);
            Debug.Log("I took damage");
        }
        if (food == "twoHrs") {
            count += (factor * 100);
            characterHealth.TakeDamage(-30f);
            Debug.Log("I took damage");
        }
        if (food == "insulin") {
            count += (factor * 100);
            characterHealth.TakeDamage(-30f);
            Debug.Log("I took damage");
        }
    }

	// Accessor for count
	public static string getCount(){
		return count.ToString();
	}

	// Pause game using timeScale, set pause flag to true
	public static void pauseGame() {
		Time.timeScale = 0f;
		paused = true;
	}

	// Resume game using timeScale, set pause flag to false
	public static void resumeGame() {
		Time.timeScale = 1f;
		paused = false;
	}

	// Accessor for paused flag
	public static bool isPaused() {
		return paused;
	}

	// Schedules a delayed resumeGame() call after passed amount of seconds have elapsed
	public static void delayedResume (float seconds) {
		float end = Time.realtimeSinceStartup + seconds;
		while (Time.realtimeSinceStartup < end) {
			// Delay resume call until real time hits desired end
		}
		gameDisplay.resumeGame ();
	}

	// Schedules a delayed pauseGame() call after passed amount of seconds have elapsed
	public static void delayedPause (float seconds) {
		float end = Time.realtimeSinceStartup + seconds;
		while (Time.realtimeSinceStartup < end) {
			// Delay pause call until real time hits desired end
		}
		gameDisplay.pauseGame ();
	}

	// Accessor for level integer value
	public static int getLevel() {
		return level;
	}
}
