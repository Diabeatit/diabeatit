using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameDisplay : MonoBehaviour {

	// Time variables for creating delays
	private float time = 3f;

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
		count = 0;
		setCountText();
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
		countText.text = "count: " + getCount();
	}

	// To be called in Update()
	// Checks current count to check for and handle win/transition condition
	public void checkProgress() {
		if ((count == 0) && (!introCheck)) {
			// Pause to show intro transition image before gameplay starts
			gameDisplay.pauseGame ();
			introCheck = true;
		} else if ((count >= 33) && (!check1)) {
			level = 1;
			gameDisplay.pauseGame ();
			winText.text = "";
			check1 = true;
		} else if ((count >= 66) && (!check2)) {
			level = 2;
			gameDisplay.pauseGame ();
			winText.text = "";
			check2 = true;
		} else if ((count >= 100) && (characterHealth.currentHealth > 0)) {
			winText.text = "YOU WIN!!!";
			// Delay 3 seconds then load home scene
			if (time > 0) {
				time -= Time.deltaTime;
			} else {
				Reset ();
				SceneManager.LoadScene ("home");
			}
		} else {

		}
	}

	// Update count with appropriate value based on food string parameter
	public static void updateDisplay(string food){
		// Level 0
		if (food == "Apple") {
			count += 1;
			characterHealth.TakeDamage(-1f);
			Debug.Log ("I took damage");
		}
		if (food == "Zucchini") {
			count += 5;
			characterHealth.TakeDamage(-5f);
			Debug.Log ("I took damage");
		}
		if (food == "Candy") {
			count -= 1;
			characterHealth.TakeDamage(3f);
			Debug.Log ("I took damage");
		}
		// Level 1
		if (food == "redMeat") {
			count += 3;
			characterHealth.TakeDamage(6f);
			Debug.Log ("I took damage");
		}
		if (food == "juiceBox") {
			count -= 4;
			characterHealth.TakeDamage(15f);
			Debug.Log ("I took damage");
		}
		if (food == "broc") {
			count += 7;
			characterHealth.TakeDamage(-10f);
			Debug.Log ("I took damage");
		}
		// Level 2
		if (food == "carrot") {
			count += 3;
			characterHealth.TakeDamage(5f);
			Debug.Log ("I took damage");
		}
		if (food == "beans") {
			count += 7;
			characterHealth.TakeDamage(-3f);
			Debug.Log ("I took damage");
		}
		if (food == "cake") {
			count -= 5;
			characterHealth.TakeDamage(10f);
			Debug.Log ("I took damage");
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
