using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

	float prevHealth = 50f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// get distance moved from CharacterHealth
		float dist = characterHealth.currentHealth - prevHealth;
		prevHealth = characterHealth.currentHealth;
		float trans = dist * 0.032f;

		Vector3 temp = new Vector3 (trans, 0, 0);
		transform.position += temp;
	}
}
