using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodSpawn : MonoBehaviour {

	public GameObject apple; //make a public gameobject for every item you want to add
	public GameObject zucchini;
	public GameObject chocolate;
	//public GameObject[] food;

    // spawn rate in seconds
	float maxSpawnRate = 10f;
	// Use this for initialization
	void Start () {

		//food = GameObject.FindGameObjectsWithTag ("Food");

		/**food = new GameObject[2]; //make a an array length is number of items
		food [0] = apple;
		food [1] = zucchini;

		for (int i = 0; i < food.Length; i++) { //only for debug purposes
			Debug.Log ("Food Object: " + food [i].name);
		}*/

		// when game starts a food and candy object will be
		// instantiated after 20 seconds
        Invoke ("spawnFood",2);
        Invoke ("spawnCandy",4);
		Invoke ("spawnFood2",6);

        // increase Difficulity every 15 seconds
        InvokeRepeating("IncreaseDifficulty",0f,5f);
	}

	// Update is called once per frame
	void Update () {
	}
    void spawnCandy() {

        //bottom-left screeen pos
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        //top right Screen pos
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        //instantiate GameObject
		GameObject candy = (GameObject)Instantiate(chocolate);

        // generate a food object at a random posistion on the far right of the
        // the screen
        candy.transform.position = new Vector2(max.x,Random.Range(min.y+.5f,max.y -.5f));

        //Schedule the next foodObject Spawning
        ScheduleCandy();

    }
    void spawnFood() {

        //bottom-left screeen pos
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        //top right Screen pos
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		//int rand = Random.Range (0, (food.Length - 1));


			//instantiate GameObject
			GameObject newFood = (GameObject)Instantiate(apple);


			// generate a food object at a random posistion on the far right of the
			// the screen
			newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

			//Schedule the next foodObject Spawning
			ScheduleFood ();


    }
	void spawnFood2() {

		//bottom-left screeen pos
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		//top right Screen pos
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		//int rand = Random.Range (0, (food.Length - 1));


		//instantiate GameObject
		GameObject newFood = (GameObject)Instantiate(zucchini);


		// generate a food object at a random posistion on the far right of the
		// the screen
		newFood.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));

		//Schedule the next foodObject Spawning
		ScheduleFood2 ();


	}
    void ScheduleCandy(){

        float spawnRate;

        if(maxSpawnRate> 1f){
            //generate the next spawn
            spawnRate = Random.Range(1f,maxSpawnRate);
        }
       else {
            spawnRate = 1f;
        }

        Invoke("spawnCandy",spawnRate);
    }
    void ScheduleFood(){

		float spawnRate;

		if(maxSpawnRate> 1f){
			//generate the next spawn
			spawnRate = Random.Range(1f,maxSpawnRate);
		}
		else {
			spawnRate = 1f;
		}

       // if(maxSpawnRate>7f){
            //generate the next spawn
       //     spawnRate = Random.Range(1f,maxSpawnRate);
       // }
       // else {
       //     spawnRate = 7f;
       // }
        Invoke("spawnFood",spawnRate);
    }
	void ScheduleFood2(){

		float spawnRate;

		if(maxSpawnRate> 1f){
			//generate the next spawn
			spawnRate = Random.Range(1f,maxSpawnRate);
		}
		else {
			spawnRate = 1f;
		}
		// if(maxSpawnRate>7f){
		//generate the next spawn
		//     spawnRate = Random.Range(1f,maxSpawnRate);
		// }
		// else {
		//     spawnRate = 7f;
		// }
		Invoke("spawnFood2",spawnRate);
	}

    void IncreaseDifficulty(){
        if (maxSpawnRate>1f){
            maxSpawnRate = maxSpawnRate - 1f;
        }
        else {
            CancelInvoke("IncreaseDifficulty");
            maxSpawnRate = 1f;
        }

    }
}