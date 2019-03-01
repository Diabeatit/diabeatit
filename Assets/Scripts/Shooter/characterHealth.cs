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
    public Image redImage;
    public float flashSpeed = 0.5f;
    public Color flashColor = new Color(255f, 0f, 0f, 255f);
    public Color defColor = new Color(0f, 0f, 0f, 0f);
    public static bool unhealthy = false;
    public static bool routine = true;
    public static Text warning;
    public int threshhold = 20;
    public GameObject WinText;



    void Start() {
		healthbar = GameObject.Find("HealthBar").GetComponent<Slider>();
		arrow = GameObject.Find ("arrow").GetComponent<Sprite> ();
        warning = GameObject.Find("Text").GetComponent<Text>();
        maxHealth = 100f;
		currentHealth = 50f;
		healthbar.value = CalculateHealth();
	}
		
	void Update() {
		currentHealth -= (1f * Time.deltaTime); // constant '1' defines how fast to reduce health
		healthbar.value = CalculateHealth (); //recalculate display

        // If health runs below 0 or over 100, game over!
        /* Need to implement a timer to give time to player
           to get back to the green zone */
        if (currentHealth <= 0) {
			currentHealth = 0f;
            Die();
		} else if (currentHealth >= 100) {
			currentHealth = 100f;
            Die();
		}
        else if (currentHealth <= (50-threshhold) || currentHealth >= (50+threshhold))
        {
            unhealthy = true;
            WinText.SetActive(false);

            if (routine == true)
            {
                StopCoroutine(flashRed());
                print("routine stopped");
                unhealthy = true;
                routine = false;
                StartCoroutine(flashRed());
                print("routine started");
            }

        }

        else
        {
            unhealthy = false;
            WinText.SetActive(true);

        }
    }

    IEnumerator flashRed()
    {
        print(unhealthy);
        if (unhealthy == true)
        {
            print("in coroutine");
            print("unhealthy");
            warning.text = "WARNING";
            redImage.color = flashColor;
            yield return new WaitForSeconds(flashSpeed);
            warning.text = "";
            redImage.color = defColor;
            yield return new WaitForSeconds(flashSpeed);
            routine = true;
            print("exit coroutine");

        }

    }


    public static void TakeDamage(float amount) {
		currentHealth += amount;
		healthbar.value = CalculateHealth ();
        
        // If health runs below 0 or over 100, game over!
        /* Need to implement a timer to give time to player
           to get back to the green zone */
        if (currentHealth <= 0f) {
			currentHealth = 0f;
			Die();
		}
        else if(currentHealth >= 100f){
            currentHealth = 100f;
            Die();
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