using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawn : MonoBehaviour {

	public GameObject foodGO;
	public GameObject candyGO;

    // spawn rate in seconds
	float maxSpawnRate = 10f;
	// Use this for initialization
	void Start () {



		// when game starts a food and candy object will be
		// instantiated after 20 seconds
        Invoke ("spawnFood",4);
        Invoke ("spawnCandy",4);

        // increase Difficulity every 30 seconds
        InvokeRepeating("IncreaseDifficulty",0f,10f);
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
        GameObject candy = (GameObject)Instantiate(candyGO);

        // generate a food object at a random posistion on the far right of the
        // the screen
        candy.transform.position = new Vector2(max.x,Random.Range(min.y,max.y));

        //Schedule the next foodObject Spawning
        ScheduleCandy();

    }
    void spawnFood() {

        //bottom-left screeen pos
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        //top right Screen pos
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        //instantiate GameObject
        GameObject food = (GameObject)Instantiate(foodGO);

        // generate a food object at a random posistion on the far right of the
        // the screen
        food.transform.position = new Vector2(max.x,Random.Range(min.y,max.y));

        //Schedule the next foodObject Spawning
        ScheduleFood();

    }
    void ScheduleCandy(){

        float spawnRate;

        if(maxSpawnRate>1f){
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

        if(maxSpawnRate>1f){
            //generate the next spawn
            spawnRate = Random.Range(1f,maxSpawnRate);
        }
        else {
            spawnRate = 1f;
        }
        Invoke("spawnFood",spawnRate);
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
