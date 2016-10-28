using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
	
	/*
	 * PlayerHealth class:
	 * Controls the player's health related actions and variables
	*/
	

	public int startingHealth = 100;
	public int currentHealth;

	public int heal = 0;

	Text healthText;
	

	void Awake () {
		healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text> ();
		currentHealth = startingHealth;
	}


	void FixedUpdate () {
		healthText.text = "Health: " + currentHealth.ToString ();
	}


	public void TakeDamage(int amount) {
		currentHealth -= amount;
	}
}