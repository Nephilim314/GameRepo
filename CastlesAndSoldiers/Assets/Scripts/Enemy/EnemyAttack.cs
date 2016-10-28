using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {


	/*
	 * EnemyAttack class:
	 * Controls the actions when it is enemy's turn to attack
	*/


	public int attackPoint = 0;

	PlayerHealth playerHealth;
	GameObject player;

	TurnController turnController;


	void Awake () {
		playerHealth = GetComponent<PlayerHealth> ();
		turnController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TurnController> ();
	}
	

	void FixedUpdate () {
		Attack ();
	}


	void Attack() {
		//Debug.Log ("turn: " + turnController.playerTurn);
		if (turnController.playerTurn == 0) {
			turnController.BeginTurn();
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent<PlayerHealth> ();
			if (playerHealth.currentHealth > 0) {
				playerHealth.TakeDamage (attackPoint);
			}
			turnController.EndTurn();
		}
	}
}
