using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class characterHealth : MonoBehaviour {
	public static float currentHealth {get; set;}
	public static float maxHealth {get; set;}
	public static Slider healthbar; 

	void Start()
	{
		healthbar = GameObject.Find("HealthBar").GetComponent<Slider>();
		maxHealth = 100f;
		currentHealth = maxHealth;

	 healthbar.value = CalculateHealth();
	}
		
	void Update() {
		currentHealth -= (1 * Time.deltaTime); //minus one every second
		healthbar.value = CalculateHealth (); //recalculate display
	}
	public static void TakeDamage(float amount)
	{
		currentHealth -= amount;
		healthbar.value = CalculateHealth ();
			if (currentHealth <= 0) Die ();
				
	}
	static float CalculateHealth() {
		return currentHealth / maxHealth;
	}
	static void  Die()
	{
		currentHealth = 0;
		SceneManager.LoadScene ("home");
		Debug.Log("Dead!");
	}
}