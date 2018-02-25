using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameDisplay : MonoBehaviour {

	// Time variables for creating delays
	private float time = 3f;

	// Count of food consumed
	private static int count;

	// Pause flag
	private static bool paused = false;

	// Checkpoint flags
	private static bool introCheck = false;
	private static bool check1 = false;
	private static bool check2 = false;
	private static bool check3 = false;
	
	// Level tracker
	private static int level = 0;

	// Text objects
	public Text countText;
	public Text winText;

	// ??
	public Scene levelToLoad;


	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText();
		winText.text = "";
	}

	// Reset static variables when game ends so they work on next load
	void Reset() {
		count = 0;
		level = 0;
		paused = false;
		introCheck = false;
		check1 = false;
		check2 = false;
		check3 = false;
	}

	// Update is called once per frame
	void Update () {
		// Check for paused state
		if (!gameDisplay.isPaused()) {
			SetCountText ();
			checkProgress ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	// To be called in Update(), sets the count text based on current count
	public void SetCountText(){
		countText.text = "count: " + getCount();
	}

	// Checks current count to check for and handle win/transition condition
	// TODO update to check status of glucose bar when implemented
	public void checkProgress() {
		if ((count == 0) && (!introCheck)){
			// Pause to show intro transition image before gameplay starts
			gameDisplay.pauseGame ();
			introCheck = true;
		} else if ((count >= 10) && (!check1)) {
			winText.text = "10!";
			level = 1;
			gameDisplay.pauseGame ();
			winText.text = "";
			check1 = true;
		} else if ((count >= 20) && (!check2)) {
			winText.text = "20!";
			level = 2;
			gameDisplay.pauseGame ();
			winText.text = "";
			check2 = true;
		} else if ((count >= 30) && (!check3)) {
			winText.text = "30!";
			level = 3;
			gameDisplay.pauseGame ();
			winText.text = "";
			check3 = true;
		} else if (count >= 40) {
			winText.text = "YOU WIN!!!";
			// Delay 3 seconds then load home scene
			if (time > 0) {
				time -= Time.deltaTime;
			} else {
				Reset ();
				SceneManager.LoadScene ("home");
			}
		}
	}

	// Update count with appropriate value based on food string parameter
	public static void updateDisplay(string food){
		if (food == "Apple") {
			count += 1;
			characterHealth.TakeDamage(-5);
			Debug.Log ("I took damage");
		}
		if (food == "Zucchini") {
			count += 5;
			characterHealth.TakeDamage (-2);
			Debug.Log ("I took damage");
		}
		if (food == "Candy") {
			count -= 1;
			characterHealth.TakeDamage (10);
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
