using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject cloudfalse;
	public GameObject cloudtrue;
	public GameObject mtrue;
	public GameObject mfalse;

	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		//Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float height = 2f * cam.orthographicSize;
		float targetWidth = height * cam.aspect;
		float cloudWidth = cloudtrue.GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth - cloudWidth;
	}

	void Update() {

		if (QuestionManager.gameOver != true) {
			if (QuestionManager.nextQ == true) {
				if (mtrue != null) {
					Destroy (mtrue);
					Destroy (mfalse);
				}
				Spawn ();
				QuestionManager.nextQ = false;
			}
		}
	}

	void Spawn() {
		Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth),
			transform.position.y, -5.0f);

		Quaternion spawnRotation = Quaternion.identity;
		Vector3 spawnPosition1 = new Vector3 (Random.Range (-maxWidth, maxWidth),
			transform.position.y, -5.0f);

		Quaternion spawnRotation1 = Quaternion.identity;
		mtrue = Instantiate (cloudtrue, spawnPosition, spawnRotation);
		mfalse = Instantiate (cloudfalse, spawnPosition1, spawnRotation1);
	}

}
