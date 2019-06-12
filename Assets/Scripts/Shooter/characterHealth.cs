using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

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
    public int threshhold = 50;
    public GameObject WinText;

    // Spring 2019
    public static Sprite HealthBarArrow;


    void Start() {
        //healthbar = GameObject.Find("HealthBar").GetComponent<Slider>();
        //arrow = GameObject.Find ("arrow").GetComponent<Sprite> ();
              warning = GameObject.Find("Text").GetComponent<Text>();
        //      maxHealth = 250f;
        //currentHealth = 125f;
        //healthbar.value = CalculateHealth();
        currentHealth = 0f; // Arrow points up, middle of green
        arrow = GameObject.Find("HealthBarArrow").GetComponent<Sprite>();
        maxHealth = -90f; // Arrow points all the way to right (high glucose)
        //healthbar.value = CalculateHealth();
	}

    void Update()
    {
        // SPRING 2019: Glucose level decline over time code moved to ArrowScript.cs
        //currentHealth -= (1f * Time.deltaTime); // constant '1' defines how fast to reduce health
                                                //healthbar.value = CalculateHealth (); //recalculate display

        if ((currentHealth < -90) || (currentHealth > 90))
        {
            // Arrow goes pass health dial -> ends game
             Die();
        }
        else if (currentHealth < 80)
        // Arrow within low glucose range -> flash LOW GLUCOSE
        {
            if (routine == true)
            {
                StopCoroutine(flashRed("LOW GLUCOSE"));
                print("routine stopped");
                routine = false;
                StartCoroutine(flashRed("LOW GLUCOSE"));
                print("routine started");
            }
        }
    }
        //       // If health runs below 0 or over 250, game over!
        //       /* Need to implement a timer to give time to player
        //          to get back to the green zone */
        //       if (currentHealth <= 0) {
        //		currentHealth = 0f;
        //           Die();
        //	} else if (currentHealth >= 250) {
        //		currentHealth = 250f;
        //           Die();
        //	}
        //       else if (currentHealth <= (150 - threshhold)) // Dial points to low glucose section
        //           // 150 is middle of glucose dial
        //       {
        //           unhealthy = true;
        //           WinText.SetActive(false);

        //           if (routine == true)
        //           {
        //               StopCoroutine(flashRed("LOW GLUCOSE"));
        //               print("routine stopped");
        //               unhealthy = true;
        //               routine = false;
        //               StartCoroutine(flashRed("LOW GLUCOSE"));
        //               print("routine started");
        //           }

        //       }
        //       else if (currentHealth >= (150 + threshhold))
        //       {
        //           unhealthy = true;
        //           WinText.SetActive(false);

        //           if (routine == true)
        //           {
        //               StopCoroutine(flashRed("HIGH GLUCOSE"));
        //               print("routine stopped");
        //               unhealthy = true;
        //               routine = false;
        //               StartCoroutine(flashRed("HIGH GLUCOSE"));
        //               print("routine started");
        //           }

        //       }
        //       else
        //       {
        //           unhealthy = false;

        //           warning.text = "";
        //           WinText.SetActive(true);

        //       }
        //   }

       public IEnumerator flashRed(string text)
       {
           print(unhealthy);
           if (unhealthy == true)
           {
               print("in coroutine");
               print("unhealthy");
               warning.text = text;
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
        // Function used in gameDisplay, amount == angle

    	// healthbar.value = CalculateHealth ();

           // If health runs below 0 or over 250, game over!
           /* Need to implement a timer to give time to player
              to get back to the green zone */
     //      if (currentHealth <= 0f) {
    	//	currentHealth = 0f;
    	//	Die();
    	//}
           //else if(currentHealth >= 250f){
           //    currentHealth = 250f;
           //    Die();
           //}
       }

        //static float CalculateHealth() {
        //	if ((currentHealth / maxHealth) > 1f) {
        //		return 1f;
        //	} else {
        //		return currentHealth / maxHealth;
        //	}
        //}

        static void Die()
        {
    		currentHealth = 90;
    		gameDisplay.Reset ();
    		SceneManager.LoadScene ("home");
    		Debug.Log("Dead!");
	    }


    //internal static void TakeDamage(float v)
    //{
    //    throw new NotImplementedException();
    //}
}
