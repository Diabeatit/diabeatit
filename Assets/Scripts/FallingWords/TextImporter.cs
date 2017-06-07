using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {

	public TextAsset textFile;
	public string[] questions;

	// Use this for initialization
	void Start () {
		if (textFile != null) {
			questions = (textFile.text.Split ('\n'));
		}
	}	
}
