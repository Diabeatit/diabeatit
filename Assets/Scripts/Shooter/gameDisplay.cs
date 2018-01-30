using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameDisplay : MonoBehaviour {

	private float time = 3f;

	private static int count;

	public Text countText;
	public Text winText;

	public Scene levelToLoad;

	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		SetCountText ();
	}

	public void SetCountText(){

		countText.text = "count: " + getCount();

		if (count >= 10) {
			winText.text = "YOU WIN!!!";
			if(time > 0){
				time-=Time.deltaTime;
			}else{
				SceneManager.LoadScene ("home");
			}
		}
	}

	public static void updateDisplay(string food){
		if (food == "Apple") {
			count += 1;
		}

		if (food == "Zucchini") {
			count += 5;
		}
		if (food == "Candy") {
			count -= 1;
		}
	}

	public static string getCount(){
		return count.ToString();
	}
}
