using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {


	/*
	 * EnemyAI class:
	 * A simple enemy AI that draws cards for itself and attacks the player
	*/


	EnemyDeck enemyDeck;

	//GameObject[] enemyHand;
	GameObject enemy;

	EnemyHealth enemyHealth;
	EnemyAttack enemyAttack;
	EnemyMoney enemyMoney;

	GameObject EnemyOffensePanel;
	GameObject EnemyDefensePanel;

	Cards cardInfo;

	GameObject deckCard;

	bool isStart = true;


	void Start () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyDeck = GameObject.FindGameObjectWithTag ("GameController").GetComponent<EnemyDeck> ();
		//enemyHand = enemyDeck.handEnemy;

		enemyAttack = enemy.GetComponent<EnemyAttack> ();
		enemyHealth = enemy.GetComponent<EnemyHealth> ();
		enemyMoney = enemy.GetComponent<EnemyMoney> ();

		EnemyOffensePanel = GameObject.FindGameObjectWithTag ("EnemyOffense");
		EnemyDefensePanel = GameObject.FindGameObjectWithTag ("EnemyDefense");
	}
	

	void FixedUpdate () {
		DrawCards ();
	}


	//draws card from his hand and places them in his slots
	void DrawCards() {
		while (enemyMoney.currentMoney > 10) {
			if (isStart) {
				foreach (GameObject g in enemyDeck.handEnemy) {
					if (g.transform.GetComponent<Cards>().earn != 0) {
						deckCard = Instantiate(g) as GameObject;
					}
				}
			} else {
				int i = Random.Range(0, enemyDeck.handEnemy.Length - 1);
				deckCard = Instantiate (enemyDeck.handEnemy[i]) as GameObject;
			}
			isStart = false;
			Destroy(deckCard.GetComponent<Draggable>());
			cardInfo = deckCard.GetComponent<Cards> ();
			if (cardInfo.type == "Offensive") {
				deckCard.transform.SetParent (EnemyOffensePanel.transform, false);
			} else if (cardInfo.type == "Defensive"){
				deckCard.transform.SetParent (EnemyDefensePanel.transform, false);
			}
			enemyAttack.attackPoint += cardInfo.attack;
			enemyHealth.currentHealth += cardInfo.health;
			enemyHealth.heal += cardInfo.heal;
			enemyMoney.currentMoney -= cardInfo.cost;
			enemyMoney.earn += cardInfo.earn;
		}
	}

}
