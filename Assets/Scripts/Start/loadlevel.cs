using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadlevel : MonoBehaviour {

	public void NextLevelButton(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}
}
