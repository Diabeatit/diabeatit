using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		speed = 8f;
	}

	// Update is called once per frame
	void Update () {

        // Get the bullet's current position
		Vector2 position = transform.position;

        // compute the bullet's new posisiton
        position = new Vector2(position.x + speed * Time.deltaTime, position.y );
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        if(transform.position.x > max.x){
            Destroy(gameObject);
        }
	}
}
