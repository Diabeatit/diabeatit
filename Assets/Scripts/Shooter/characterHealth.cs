using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class characterHealth : MonoBehaviour {
	public static float currentHealth {get; set;}
	public static float maxHealth {get; set;}
	public static Slider healthbar; 
	public static Sprite arrow;


	void Start() {
		healthbar = GameObject.Find("HealthBar").GetComponent<Slider>();
		arrow = GameObject.Find ("arrow").GetComponent<Sprite> ();
		maxHealth = 100f;
		currentHealth = 50f;
		healthbar.value = CalculateHealth();
	}
		
	void Update() {
		currentHealth -= (0.25f * Time.deltaTime); //minus one every second
		healthbar.value = CalculateHealth (); //recalculate display

		if (currentHealth <= 0) {
			currentHealth = 0f;
		} else if (currentHealth >= 100) {
			currentHealth = 100f;
		}
	}

	public static void TakeDamage(float amount) {
		currentHealth += amount;
		healthbar.value = CalculateHealth ();
		if (currentHealth <= 0) {
			currentHealth = 0;
			Die ();
		}
	}

	static float CalculateHealth() {
		if ((currentHealth / maxHealth) > 1f) {
			return 1f;
		} else {
			return currentHealth / maxHealth;
		}
	}

	static void  Die() {
		currentHealth = 0;
		gameDisplay.Reset ();
		SceneManager.LoadScene ("home");
		Debug.Log("Dead!");
	}
}