using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {

    // this is our star prefab
    public GameObject StarGo;

    public int maxStars; // max stars

    // color array

    Color[] starColor = {
        new Color(0.5f,0.5f,1f), //blue;
        new Color(0.0f,1f,1f), //green ;
        new Color(1f,1f,0f), //yellow ;
        new Color(1f,0.0f,0f) //red;
    };


	// Use this for initialization
	void Start () {

        //bottom left point
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        // top right
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        //create stars
        for (int i =0; i<maxStars; i++) {
            GameObject star = (GameObject)Instantiate(StarGo);

            // set the Color
            star.GetComponent<SpriteRenderer>().color = starColor[i % starColor.Length];

            // set starPosistion
            star.transform.position = new Vector2(Random.Range(min.x,max.x),Random.Range(min.y,max.y));

            // set random star speed
			star.GetComponent<Star>().speed = 1f * Random.value +0.5f;

            // make the star a child of StarGenerator
            star.transform.parent = transform;
        }



	}

	// Update is called once per frame
	void Update () {


	}
}
