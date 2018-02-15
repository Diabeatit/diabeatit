using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour {
	//link this script to an image on the canvas
	// Use this for initialization
	void Start () {
		//destroy transition image after 10 seconds have elapsed
		Destroy(gameObject, 10f);
	}
}
