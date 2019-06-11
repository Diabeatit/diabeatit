using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public float decline; // For decreasing glucose level over time

	// Use this for initialization
	void Start () {
        decline = 0;
    }
	
	// Update is called once per frame
	void Update () {
        decline += (3f * Time.deltaTime); // Bigger constant = faster decline rate
        // SPRING 2019: should be moved back to characterHealth.cs or this script
        // combined with characterHealth to account for increased points depending on
        // arrow position


        float dist = -1 * characterHealth.currentHealth;
        // Food items give pos value but rotating towards high glucose requires neg value
        // Multiply by -1 to rotate in correct direction
        // characterHealth.currentHealth is sum of angles caused by tapped items


        transform.rotation = Quaternion.Euler(0, 0, decline+dist);
        // Rotates arrow

    }
}
