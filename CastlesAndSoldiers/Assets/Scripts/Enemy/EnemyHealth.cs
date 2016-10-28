using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	
	
	/*
	 * EnemyHealth class:
	 * Controls the enemy's health related actions and variables
	*/
	

	public int startingHealth = 100;
	public int currentHealth;

	public int heal = 0;

	Text healthText;
	
	bool isDead;


	void Awake () {
		healthText = GameObject.FindGameObjectWithTag("EnemyHealthText").GetComponent<Text> ();
		currentHealth = startingHealth;
	}
	
	
	void FixedUpdate () {
		healthText.text = "Health: " + currentHealth.ToString();
	}
	
	public void TakeDamage(int amount) {
		currentHealth -= amount;
	}
}
