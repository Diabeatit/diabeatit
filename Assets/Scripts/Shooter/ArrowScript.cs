using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    float prevHealth = 50f;
    public float position;

	// Use this for initialization
	void Start () {
        position = transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {
        float dist = (characterHealth.currentHealth - 50f) * 0.035f;
        transform.position = new Vector3 (position+dist, transform.position.y, transform.position.z);
        print(transform.position.x);
	}
}
