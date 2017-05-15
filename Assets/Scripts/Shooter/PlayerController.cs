using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //public bool characterInQuicksand;

    private Rigidbody2D rb2d;
    private static int count;

	public Text countText;
	public GameObject laser; // this is the players laser prefab
	public GameObject laserPosition;
	public float speed;

	// Use this for initialization

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        // intitialize the count to zero
        count = 0;
        SetCountText();

	}

	// Update is called just before applying any physics calculations

	void Update(){
		SetCountText ();
		// fire bullet when space bar is pressed
		if (Input.GetKeyDown ("space")) {

			//instantiate the laser
			GameObject laser1 = (GameObject)Instantiate (laser);

			// set the lasers initial position
			laser1.transform.position = laserPosition.transform.position;

		}
	}
	void FixedUpdate () {

		// fire bullets when the spacebar is pressed
        // Grabs input from the player through the keyboard
        // and stores in a float
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rb2d.AddForce(movement*speed);

	}

    // set the boolean variable to true whenever we touch another object
    // this method is called whenever our player touches another
    // 2D trigger collider and it passes in a reference to the 2d object
    // that it collided with
    // So if the game object collided with has a tag of "Food" then we will
    // set the GO active field to false
    void OnTriggerEnter2D(Collider2D other) {



       // increment the count the destroy the food Object
       if (other.gameObject.CompareTag("Food")){
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
			decCount();
        }

        //decriment the count if collide with candy
        else if (other.gameObject.CompareTag("Candy")){
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
			decCount();

        }
    }

    public void SetCountText(){

		countText.text = "count: " + getCount();
    }

	public static void incCount(){
		count ++;
	}
	public static void decCount(){
		count--;
	}

	public static string getCount(){
		return count.ToString();
	}


}
