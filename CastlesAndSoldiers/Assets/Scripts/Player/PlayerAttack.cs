using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
	
	
	/*
	 * PlayerAttack class:
	 * Controls the actions when it is players's turn to attack
	*/
	

	public int attackPoint = 0;
	
	Cards cardInfo;

	TurnController turnController;
	Button endTurnButton;

	EnemyHealth enemyHealth;


	void Awake () {
		turnController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TurnController> ();
		endTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();
	}
	

	void FixedUpdate () {
		Attack();
	}


	void Attack() {
		//Debug.Log ("turn: " + turnController.playerTurn);
		if (turnController.giveBonus == false) {
			turnController.BeginTurn();
		}
		turnController.giveBonus = true;
		endTurnButton.onClick.AddListener (() => turnController.pressButton = true);
		if (turnController.playerTurn == 1 && turnController.pressButton == true) {
			GameObject enemy = GameObject.FindGameObjectWithTag ("Enemy");
			enemyHealth = enemy.GetComponent<EnemyHealth> ();
			if (enemyHealth.currentHealth > 0) {
				enemyHealth.TakeDamage (attackPoint);
			}
			turnController.giveBonus = false;
			turnController.EndTurn();
		}
	}
}
