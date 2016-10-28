using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDeck : MonoBehaviour {


	/*
	 * EnemyDeck class:
	 * Makes the deck for the enemy and handles the hand
	*/


	Object[] cardList;
	List<GameObject> enemyDeck = new List<GameObject>();
	public static int enemyHandSize = 6;
	
	public GameObject[] handEnemy = new GameObject[enemyHandSize];


	//places cards in enemy's hand
	void Start () {
		PlaceCardsInEnemyHand ();
	}


	void FixedUpdate () {
		while (handEnemy.Length < enemyHandSize) {
			AddCardsToEnemyHand ();
		}
	}
	

	//generates a temporary deck for the enemy
	void GenerateEnemyCards() {
		cardList = Resources.LoadAll("Roman");
		int j = cardList.Length;
		for (int i = 0; i < j; i++) {
			GameObject tempCard = cardList[i] as GameObject;
			enemyDeck.Add(tempCard);
		}
	}
	

	//generates a deck list consisting of 42 cards
	List<GameObject> GenerateEnemyDeck() {
		for (int i = 0; i < 3; i++) {
			GenerateEnemyCards();
		}
		return enemyDeck;
	}
	

	//places 6 cards in enemy's hand
	void PlaceCardsInEnemyHand() {
		GenerateEnemyDeck ();
		foreach(GameObject g in enemyDeck) {
			Debug.Log(g.ToString());
		}
		Debug.Log (handEnemy.Length);
		for (int x = 0; x < enemyHandSize; x++) {
			int i = Random.Range(0, enemyDeck.Count - 1);
			handEnemy[x] = enemyDeck[i];
			enemyDeck.RemoveAt(i);
		}
	}


	//adds cards to the enemy's hand whenever the enemy draws card from his hand
	public GameObject[] AddCardsToEnemyHand() {
		int j = handEnemy.Length;
		//Debug.Log (j);
		if (j < 6) {
			int i = Random.Range(0, enemyDeck.Count - 1);
			handEnemy[j - 1] = enemyDeck[i];
			enemyDeck.RemoveAt(i);
		}
		return handEnemy;
	}

}
