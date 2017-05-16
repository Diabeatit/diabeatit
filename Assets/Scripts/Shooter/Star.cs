using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    // speed of the star
    public float speed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        // get current position of the star
        Vector2 pos = transform.position;

        // get new posistion
        pos = new Vector2( pos.x - speed * Time.deltaTime, pos.y);

        // update to the new posistion
        transform.position = pos;

        // get min and max points
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        //if star goes beyond the left edge than randomly position it
        // the far right between the top and the bottom
        if(pos.x<min.x){
            transform.position = new Vector2(max.x,Random.Range(min.y,max.y));
        }


	}
}
