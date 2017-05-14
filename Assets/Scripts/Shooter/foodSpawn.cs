using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawn : MonoBehaviour {

	public GameObject foodGO;

    // spawn rate in seconds
    float maxSpawnRate;
	// Use this for initialization
	void Start () {

        maxSpawnRate = 5f;
        Invoke ("spawnFood",maxSpawnRate);

        // increase Difficulity every 30 seconds
        InvokeRepeating("IncreaseDifficulty",0f,30f);
	}

	// Update is called once per frame
	void Update () {
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
        Schedule();

    }
    void Schedule(){

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
            maxSpawnRate--;
        }
        else {
            CancelInvoke("IncreaseDifficulty");
            maxSpawnRate = 1f;
        }

    }
}
