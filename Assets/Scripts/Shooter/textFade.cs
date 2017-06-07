using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textFade : MonoBehaviour {

	public float time = 4f; //Seconds to read the text

	void Start ()
	{     
		Destroy(gameObject, time);
	}
	

}
