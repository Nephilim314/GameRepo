using UnityEngine;
using System.Collections;

public class TurnController : MonoBehaviour {


	/*
	 * TurnController class:
	 * handles the switching of turns between player and enemy
	*/


	public int playerTurn = 1;
	public string turn = "Player";
	public bool pressButton = false;

	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;

	PlayerMoney playerMoney;
	EnemyMoney enemyMoney;

	public bool giveBonus = false;


	void Awake() {
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		enemyHealth = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyHealth> ();

		playerMoney = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMoney> ();
		enemyMoney = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyMoney> ();
	}


	//called to end the turn
	public void EndTurn() {
		if (playerTurn == 1) {
			turn = "Player";
			playerTurn = 0;
		} else if (playerTurn == 0) {
			turn = "Opponent";
			playerTurn = 1;
		}
		pressButton = false;
		Debug.Log (turn + " attacked");
	}


	//called to begin turn, gives the required bonuses
	public void BeginTurn() {
		if (playerTurn == 1) {
			playerHealth.currentHealth += playerHealth.heal;
			playerMoney.currentMoney += playerMoney.earn;
			playerMoney.currentMoney += 1;
		} else if (playerTurn == 0) {
			enemyHealth.currentHealth += enemyHealth.heal;
			enemyMoney.currentMoney += enemyMoney.earn;
			enemyMoney.currentMoney += 1;
		}
	}
}


