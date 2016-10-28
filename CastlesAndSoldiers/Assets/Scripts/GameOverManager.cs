using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {


	/*
	 * GameOverManager class:
	 * shows game over screen or victory screen whenever player/enemy is defeated
	 * and then restarts the game after 5 seconds
	*/


	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	float restartDelay = 5f;
	
	float restartTimer;

	Text text;
	Image image;


	void Awake () {
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		enemyHealth = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyHealth> ();

		text = GameObject.FindGameObjectWithTag ("GameOverText").GetComponent<Text>();
		image = GameObject.FindGameObjectWithTag ("GameOver").GetComponent<Image>();
	}


	void FixedUpdate () {
		if (playerHealth.currentHealth <= 0) {
			image.enabled = true;
			text.enabled = true;
			restartTimer += Time.deltaTime;
		} else if(enemyHealth.currentHealth <= 0) {
			image.enabled = true;
			text.text = "You Won!";
			text.enabled = true;
			restartTimer += Time.deltaTime;
		}
		if(restartTimer >= restartDelay) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}