using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {


	/*
	 * Deck class:
	 * Makes the deck for the player and handles the hand
	*/


	Object[] cardList;
	List<GameObject> deck = new List<GameObject>();
	public static int handSize = 6;

	GameObject panel;
	GameObject[] hand = new GameObject[handSize];


	//get the hand GameObject and place cards in it
	void Start () {
		panel = GameObject.FindGameObjectWithTag ("Hand");
		PlaceCardsInHand ();
	}


	//call AddCardsToHand function
	void FixedUpdate () {
		AddCardsToHand ();
	}


	//generate a temporary deck consisting of all the Roman prefabs
	void GenerateCards() {
		cardList = Resources.LoadAll("Roman");
		int j = cardList.Length;
		for (int i = 0; i < j; i++) {
			GameObject tempCard = cardList[i] as GameObject;
			deck.Add(tempCard);
		}
	}


	//generate a deck list of 42 cards
	List<GameObject> GenerateDeck() {
		for (int i = 0; i < 3; i++) {
			GenerateCards();
		}
		return deck;
	}


	//place 6 cards in the hand after making the deck
	void PlaceCardsInHand() {
		Debug.Log ("hand : " + hand.Length);
		GenerateDeck ();
		if (panel != null) {
			for (int x = 0; x < handSize; x++) {
				int i = Random.Range (0, deck.Count - 1);
				hand[x] = deck[i];
				deck.RemoveAt(i);
				GameObject deckCard = Instantiate (hand[x]) as GameObject;
				deckCard.transform.SetParent (panel.transform, false);
			}
		} else {
			Debug.Log("empty panel");
		}
	}


	//add cards to the hand whenever the player draws card from his hand
	void AddCardsToHand() {
		int j = panel.transform.childCount;
		if (j < 6) {
			int i = Random.Range (0, deck.Count - 1);
			hand[j - 1] = deck[i];
			deck.RemoveAt(i);
			GameObject deckCard = Instantiate (hand[j - 1]) as GameObject;
			deckCard.transform.SetParent (panel.transform, false);
		}
	}

}
