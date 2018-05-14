using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodSpawn : MonoBehaviour {

	// Counters for future implementation of tracking touch accuracy
	public static int foodSpawned;
	public static int foodConsumed;

	/*	Guide to adding new food types:
	 * 	(copy existing format for each section)
	 * 		1.	Declare a GameObject corresponding to the new food type.
	 * 		2.	Add an entry for the new food type in the appropriate food
	 * 			category array at the index corresponding to the level in 
	 * 			which it is introduced.
	 * 		3.	Add an entry for the new food type in destroyFood().
	 * 		4.	Add an entry for the new food type in instantiateNewFood().
	 * 
	 * */

	// Level 0
	public GameObject apple; 
	public GameObject zucchini;
	public GameObject chocolate;
	// Level 1
	public GameObject redMeat;
	public GameObject juiceBox;
	public GameObject broc;
	// Level 2
	public GameObject beans;
	public GameObject cake;
	public GameObject carrot;

	// Food categories, indexed based on the level each food is introduced
	public string[] healthy = 	{	"zucchini",		// Level 0
									"broc",			// Level 1
									"beans"};		// Level 2
	public string[] unhealthy = {	"chocolate",	// Level 0
									"juiceBox",		// Level 1
									"cake"};		// Level 2
	public string[] mixed = 	{	"apple",		// Level 0
									"redMeat",		// Level 1
									"carrot"};		// Level 2

	private bool wasPaused =  false;

    // Spawn rate in seconds
	float maxSpawnRate = 10f;

	// Use this for initialization
	void Start () {
		randomSpawn ();
		// increase Difficulity every 15 seconds
		InvokeRepeating ("IncreaseDifficulty", 0f, 50f);
	}

	// Update is called once per frame
	void Update () {
		// Check for paused state
		if (!gameDisplay.isPaused ()) {
			// Insert what to do when game is not paused here
			if (wasPaused) {
				restart ();
				wasPaused = false;
			}
		} else {
			// Insert what to do when game is paused here
			wasPaused = true;
			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	// To be called after a pause
	// Restarts food spawning
	void restart() {
		randomSpawn ();
		InvokeRepeating ("IncreaseDifficulty", 0f, 50f);
	}

	/*	Destroys existing food objects on the screen
	 * 
	 * */
	void destroyFood() {
		GameObject[] currentFood = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("Zucchini");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("Candy");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("redMeat");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("beans");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("cake");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("juiceBox");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("carrot");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
		currentFood = GameObject.FindGameObjectsWithTag ("broc");
		foreach (GameObject food in currentFood) {
			GameObject.Destroy (food);
		}
	}

	/* Spawns a food object based on current level and randomly generated number
	 * 
	 * */
	void randomSpawn() {
		if (!gameDisplay.isPaused ()) {
			// Pick random from 0 to 3 to choose healthy/unhealthy/mixed string array
			int randomFoodCategory = Random.Range (0, 3);
			// Then pick random 0 to (current level + 1) for index of the chosen array
			int randomLevelInCategory = Random.Range (0, (gameDisplay.getLevel () + 1));
			// Spawn food based on the random numbers generated
			switch (randomFoodCategory) {
			case 0:
				spawnFood (healthy [randomLevelInCategory]);
				break;
			case 1:
				spawnFood (unhealthy [randomLevelInCategory]);
				break;
			case 2:
				spawnFood (mixed [randomLevelInCategory]);
				break;
			default:
				break;
			}
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	/*	Increases spawn rate up to the max
	 * 
	 * */
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

	/*	Schedules the next food to be spawned based on the current spawnRate
	 * 
	 * */
	void scheduleNext() {
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}

			Invoke("randomSpawn",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	/*	Spawns a new instantiated GameObject of the type corresponding to the given string
	 * 	precon:	a GameObject corresponding to the input string has been declared
	 * 
	 * */
	void spawnFood(string foodName) {
		if (!gameDisplay.isPaused ()) {
            //bottom-left screeen pos
            Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
            //top right Screen pos
            Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
            //instantiate GameObject
            GameObject newFood = instantiateNewFood(foodName);
            /*
            //generate a y coord and place a test box there to test for collision
            //recalculate y until no collision
            bool validPos = false;
            float y = 0;
            //GameObject testBox = GameObject.FindGameObjectWithTag("testBox");
            if (!validPos) {
            */
            float y = Random.Range(min.y + .5f, max.y - 1.5f);
            /*
                //testBox.transform.position = new Vector2(max.x, y);
                Collider2D collidesWith = Physics2D.OverlapBox(new Vector2(min.x, y), new Vector2(20f, 20f), 0f);
                if (!collidesWith) {
                    Debug.Log("no collision");
                    validPos = true;
                } else {
                    Debug.Log("COLLISION");
                }
            }
            */
            // generate a food object at a random posistion on the far right of the the screen
            // with a y coord below the top ui bar
            newFood.transform.position = new Vector2 (max.x, y);
            foodSpawned++;
            //Schedule the next foodObject Spawning
            scheduleNext();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	/*	Instantiates a GameObject for a given food based on the given string
	 * 	precon:	a GameObject corresponding to the input string has been declared
	 * 
	 * */
	GameObject instantiateNewFood(string foodName) {
		GameObject newFood;
		switch (foodName) {
		case "apple":
			newFood = (GameObject)Instantiate (apple);
			break;
		case "zucchini":
			newFood = (GameObject)Instantiate (zucchini);
			break;
		case "chocolate":
			newFood = (GameObject)Instantiate (chocolate);
			break;
		case "redMeat":
			newFood = (GameObject)Instantiate (redMeat);
			break;
		case "beans":
			newFood = (GameObject)Instantiate (beans);
			break;
		case "cake":
			newFood = (GameObject)Instantiate (cake);
			break;
		case "juiceBox":
			newFood = (GameObject)Instantiate (juiceBox);
			break;
		case "carrot":
			newFood = (GameObject)Instantiate (carrot);
			break;
		case "broc":
			newFood = (GameObject)Instantiate (broc);
			break;
		default:
			newFood = null;
			break;
		}
		return newFood;
	}
}