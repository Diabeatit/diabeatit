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

    // Food/other items implemented Spring 2019
    public GameObject appleJuice;
    public GameObject bread;
    public GameObject broccoli;
    public GameObject cheese;
    public GameObject cherry;
    public GameObject chicken;
    public GameObject cola;
    public GameObject cupcake;
    public GameObject donut;
    public GameObject fries;
    public GameObject grapes;
    public GameObject iceCream;
    public GameObject milk;
    public GameObject pancakes;
    public GameObject pizza;
    public GameObject water;
    public GameObject oneHrFifteenMin;
    public GameObject oneHrThirtyMin;
    public GameObject oneHrFourtyFiveMin;
    public GameObject twoHrs;
    public GameObject insulin;


    // Food categorized by glycemic load level
    // Items in minusGlucose were arbitrarily assigned values
    // highGlucose contains game point values between 58-100
    public string[] highGlucose =   {
                                    "cola",
                                    "cupcake",
                                    "donut",
                                    "fries",
                                    "iceCream",
                                    "pancakes"};
    // minusGlucose contains game point values that decrease sugar level
    public string[] minusGlucose = {
                                    "water",
                                    "oneHrFifteenMin",
                                    "oneHrThirtyMin",
                                    "oneHrFourtyFiveMin",
                                    "twoHrs",
                                    "insulin"};
    // medGlucose contains game point values between 50-62
	public string[] medGlucose = 	{
                                    "pizza",
                                    "cheese",
                                    "broccoli",
                                    "bread",
                                    "appleJuice"};
    // lowGlucose contains game point values between 11-46
    public string[] lowGlucose = {"milk",
                                 "chicken",
                                 "cherry",
                                 "grapes"};

	private bool wasPaused =  false;

    // Spawn rate in seconds
	float maxSpawnRate = 10f;

    // Last successful spawn's y coord
    float lastSpawnY;
    // Flag for setting lastSpawnY
    bool firstSpawn = true;

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
		InvokeRepeating ("IncreaseDifficulty", 0f, 60f);
	}

	/*	Destroys existing food objects on the screen
	 * 
	 * */
	void destroyFood() {
		GameObject[] 
        currentFood = GameObject.FindGameObjectsWithTag("appleJuice");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("bread");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("broccoli");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("cheese");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("cherry");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("chicken");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("cola");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("cupcake");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("donut");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("fries");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("grapes");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("iceCream");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("milk");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("pancakes");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("pizza");
        foreach (GameObject food in currentFood) {
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("water");
        foreach (GameObject food in currentFood){
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("oneHrFifteenMin");
        foreach (GameObject food in currentFood){
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("oneHrThirtyMin");
        foreach (GameObject food in currentFood){
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("oneHrFourtyFiveMin");
        foreach (GameObject food in currentFood){
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("twoHrs");
        foreach (GameObject food in currentFood){
            Destroy(food);
        }
        currentFood = GameObject.FindGameObjectsWithTag("insulin");
        foreach (GameObject food in currentFood){
            Destroy(food);
        }
    }

	/* Spawns a food object based on current level and randomly generated number
	 * 
	 * */
     // SP2019 NOTE: FUNCTION ADDED BY PREVIOUS QUARTER. CURRENTLY ALTERED TO NOT HAVE LEVELS
	void randomSpawn() {
        Debug.Log("randomSpawn: entered");
		if (!gameDisplay.isPaused ()) {
            Debug.Log("randomSpawn: game not paused");
			// Pick random case from 0 to 4 to choose low, med, high and neg. Glucose 
            // string array or default
			int randomFoodCategory = Random.Range (0, 4);
            int randomLevelInCategory = 0; // For choosing random element in string
            // Spawn food based on the random numbers generated
            switch (randomFoodCategory)
            {
			case 0:
                randomLevelInCategory = Random.Range(0, highGlucose.Length);
                spawnFood(highGlucose[randomLevelInCategory]);
				break;
			case 1:
                randomLevelInCategory = Random.Range(0, minusGlucose.Length);
                spawnFood (minusGlucose [randomLevelInCategory]);
				break;
			case 2:
                randomLevelInCategory = Random.Range(0, medGlucose.Length);
                spawnFood (medGlucose [randomLevelInCategory]);
				break;
            case 3:
                randomLevelInCategory = Random.Range(0, lowGlucose.Length);
                spawnFood (lowGlucose [randomLevelInCategory]);
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
     // SPRING 2019: function currently not used bc levels were removed
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

			if (maxSpawnRate > 2f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 2f;
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
            
            //recalculate y until no collision
            bool validPos = false;
            float y = 0;
            while (!validPos) {
                y = Random.Range(min.y + .5f, max.y - 1.5f);
                
                if (!firstSpawn && Mathf.Abs(y - lastSpawnY) > 2f) {
                    validPos = true;
                    lastSpawnY = y;
                } else if (firstSpawn) {
                    firstSpawn = false;
                    validPos = true;
                    lastSpawnY = y;
                }
            }
            
            // generate a food object at a random posistion on the far right of the the screen
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
        case "appleJuice":
            newFood = (GameObject)Instantiate (appleJuice);
            break;
        case "bread":
            newFood = (GameObject)Instantiate (bread);
            break;
        case "broccoli":
            newFood = (GameObject)Instantiate (broccoli);
            break;
        case "cheese":
            newFood = (GameObject)Instantiate (cheese);
            break;
        case "cherry":
            newFood = (GameObject)Instantiate (cherry);
            break;
        case "chicken":
            newFood = (GameObject)Instantiate (chicken);
            break;
        case "cola":
            newFood = (GameObject)Instantiate (cola);
            break;
        case "cupcake":
            newFood = (GameObject)Instantiate (cupcake);
            break;
        case "donut":
            newFood = (GameObject)Instantiate (donut);
            break;
        case "fries":
            newFood = (GameObject)Instantiate (fries);
            break;
        case "grapes":
            newFood = (GameObject)Instantiate (grapes);
            break;
        case "iceCream":
            newFood = (GameObject)Instantiate (iceCream);
            break;
        case "milk":
            newFood = (GameObject)Instantiate (milk);
            break;
        case "pancakes":
            newFood = (GameObject)Instantiate (pancakes);
            break;
        case "pizza":
            newFood = (GameObject)Instantiate (pizza);
            break;
        case "water":
            newFood = (GameObject)Instantiate (water);
            break;
        case "oneHrFifteenMin":
            newFood = (GameObject)Instantiate (oneHrFifteenMin);
            break;
        case "oneHrThirtyMin":
            newFood = (GameObject)Instantiate (oneHrThirtyMin);
            break;
        case "oneHrFourtyFiveMin":
            newFood = (GameObject)Instantiate (oneHrFourtyFiveMin);
            break;
        case "twoHrs":
            newFood = (GameObject)Instantiate (twoHrs);
            break;
        case "insulin":
            newFood = (GameObject)Instantiate (insulin);
            break;
        default:
		    newFood = null;
		    break;
		}
		return newFood;
	}
}