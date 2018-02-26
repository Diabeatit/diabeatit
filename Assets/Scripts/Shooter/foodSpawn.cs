using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodSpawn : MonoBehaviour {

	// Counters for tracking touch accuracy
	public static int foodSpawned;
	public static int foodConsumed;

	// Make a public gameobject for every item you want to add
	public GameObject apple; 
	public GameObject zucchini;
	public GameObject chocolate;
	public GameObject redMeat;
	public GameObject beans;
	public GameObject cake;
	public GameObject juiceBox;
	public GameObject carrot;
	public GameObject broc;
	//private bool wasPaused =  false;

	//public GameObject[] food;

    // Spawn rate in seconds
	float maxSpawnRate = 10f;

	// Use this for initialization
	void Start () {
			Time.timeScale = 1;
			Invoke ("spawnFood", 2);
			Invoke ("spawnCandy", 4);
			Invoke ("spawnFood2", 6);
			//lv2
			Invoke ("spawnFoodl2a", 32);
			Invoke ("spawnFoodl2b", 34);
			Invoke ("spawnFoodl2c", 36);
			Debug.Log ("level 2 baby");
			//lv3
			Invoke ("spawnFoodl3a", 62);
			Invoke ("spawnFoodl3b", 64);
			Invoke ("spawnFoodl3c", 66);
			Debug.Log ("level 3 baby");
			// when game starts a food and candy object will be
			// instantiated after 2 seconds
			// increase Difficulity every 15 seconds
			InvokeRepeating ("IncreaseDifficulty", 0f, 5f);
	}

		
	// Restart spawn process from beginning
	// Call after pause
	public void Restart () {
	}

	// Update is called once per frame

	void Update () {
		// Check for paused state
		if (!gameDisplay.isPaused ()) {
			// Insert what to do when game is not paused here
			/*
			if (wasPaused) {
				Restart ();
				wasPaused = false;
			}
			*/
		} else {
			// Insert what to do when game is paused here
			//wasPaused = true;
			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

    void spawnCandy() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

			//instantiate GameObject
			GameObject candy = (GameObject)Instantiate (chocolate);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			candy.transform.position = new Vector2 (max.x, Random.Range (min.y + .5f, max.y - .5f));

			//Schedule the next foodObject Spawning
			ScheduleCandy ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void spawnFood() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(apple);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFood ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void spawnFood2() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(zucchini);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFood2 ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	void spawnFoodl2a() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(redMeat);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFoodl2a();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnFoodl2b() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(juiceBox);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFoodl2b();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnFoodl2c() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(broc);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFoodl2c();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnFoodl3a() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(carrot);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFoodl3a();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnFoodl3b() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(beans);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFoodl3b();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnFoodl3c() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//int rand = Random.Range (0, (food.Length - 1));

			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(cake);
			foodSpawned++;

			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFoodl3c();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	void ScheduleCandy(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}

			Invoke("spawnCandy",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void ScheduleFood(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			// if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			// } else {
			//     spawnRate = 7f;
			// }
			Invoke("spawnFood",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void ScheduleFood2(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			//if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			//} else {
			//		spawnRate = 7f;
			//}
			Invoke("spawnFood2",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	//level 2
	void ScheduleFoodl2a(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			//if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			//} else {
			//		spawnRate = 7f;
			//}
			Invoke("spawnFoodl2a",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void ScheduleFoodl2b(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			//if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			//} else {
			//		spawnRate = 7f;
			//}
			Invoke("spawnFoodl2b",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void ScheduleFoodl2c(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			//if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			//} else {
			//		spawnRate = 7f;
			//}
			Invoke("spawnFoodl2c",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	//level 3
	void ScheduleFoodl3a(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			//if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			//} else {
			//		spawnRate = 7f;
			//}
			Invoke("spawnFoodl3a",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void ScheduleFoodl3b(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			//if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			//} else {
			//		spawnRate = 7f;
			//}
			Invoke("spawnFoodl3b",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void ScheduleFoodl3c(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}
			//if(maxSpawnRate>7f){
			//generate the next spawn
			//		spawnRate = Random.Range(1f,maxSpawnRate);
			//} else {
			//		spawnRate = 7f;
			//}
			Invoke("spawnFoodl3c",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	void IncreaseDifficulty(){
		if (!gameDisplay.isPaused ()) {
			if (maxSpawnRate > 1f) {
				maxSpawnRate = maxSpawnRate - 1f;
			} else {
				CancelInvoke ("IncreaseDifficulty");
				maxSpawnRate = 1f;
			}
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
}