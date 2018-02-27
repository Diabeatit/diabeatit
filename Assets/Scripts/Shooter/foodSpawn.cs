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
	// Destroys existing food objects and restarts spawns
	void restart() {
		destroyFood ();
		randomSpawn ();
		InvokeRepeating ("IncreaseDifficulty", 0f, 50f);
	}

	// Destroy existing food objects
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

	// Spawns a food object based on current level and randomly generated number
	void randomSpawn() {
		if (!gameDisplay.isPaused ()) {
			// Get random float between 0.0 and 1.0
			float rand = Random.value;
			// Pick from available foods based on current level and value of rand
			if (gameDisplay.getLevel () == 0) {
				if (rand < 0.33f) {
					spawnApple ();
				} else if (rand < 0.66f) {
					spawnChocolate ();
				} else {
					spawnZucchini ();
				}
			} else if (gameDisplay.getLevel () == 1) {
				if (rand < 0.33f) {
					if (rand < 0.165f) {
						spawnApple ();
					} else {
						spawnRedMeat ();
					}
				} else if (rand < 0.66f) {
					if (rand < 0.495f) {
						spawnChocolate ();
					} else {
						spawnJuiceBox ();
					}
				} else {
					if (rand < 0.83f) {
						spawnZucchini ();
					} else {
						spawnBroccoli ();
					}
				}
			} else if (gameDisplay.getLevel () == 2) {
				if (rand < 0.33f) {
					if (rand < 0.11f) {
						spawnApple ();
					} else if (rand < 0.22f) {
						spawnRedMeat ();
					} else {
						spawnCarrot ();
					}
				} else if (rand < 0.66f) {
					if (rand < 0.44f) {
						spawnChocolate ();
					} else if (rand < 0.55f) {
						spawnJuiceBox ();
					} else {
						spawnBeans ();
					}
				} else {
					if (rand < 0.77f) {
						spawnZucchini ();
					} else if (rand < 0.88f) {
						spawnBroccoli ();
					} else {
						spawnCake ();
					}
				}
			}
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	// Increase spawn rate up to the max
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

    void spawnChocolate() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate (chocolate);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y + .5f, max.y - .5f));
			//Schedule the next foodObject Spawning
			scheduleNext ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void spawnApple() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(apple);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void spawnZucchini() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(zucchini);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext ();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	void spawnRedMeat() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(redMeat);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnJuiceBox() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(juiceBox);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnBroccoli() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(broc);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnCarrot() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(carrot);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnBeans() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(beans);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void spawnCake() {
		if (!gameDisplay.isPaused ()) {
			//bottom-left screeen pos
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			//top right Screen pos
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(cake);
			foodSpawned++;
			// generate a food object at a random posistion on the far right of the the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
			//Schedule the next foodObject Spawning
			scheduleNext();
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}

	/* Old schedule functions replaced by scheduleNext() calling randomSpawn()
	void scheduleChocolate(){
		if (!gameDisplay.isPaused ()) {
			float spawnRate;

			if(maxSpawnRate> 1f){
				//generate the next spawn
				spawnRate = Random.Range(1f,maxSpawnRate);
			} else {
				spawnRate = 1f;
			}

			Invoke("spawnChocolate",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void scheduleApple(){
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
			Invoke("spawnApple",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
    }

	void scheduleZucchini(){
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
			Invoke("spawnZucchini",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	//level 2
	void scheduleRedMeat(){
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
			Invoke("spawnRedMeat",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void scheduleJuiceBox(){
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
			Invoke("spawnJuiceBox",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void scheduleBroccoli(){
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
			Invoke("spawnBroccoli",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	//level 3
	void scheduleCarrot(){
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
			Invoke("spawnCarrot",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void scheduleBeans(){
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
			Invoke("spawnBeans",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	void scheduleCake(){
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
			Invoke("spawnCake",spawnRate);
		} else {
			// Insert what to do when game is paused here

			// Then call resumeGame() to change paused state
			//gameDisplay.resumeGame();
		}
	}
	*/
}