using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Cards : MonoBehaviour {


	/*
	 * Cards class:
	 * Stores different values for the cards
	*/


	public string type;
	public int cost;
	public int health;
	public int attack;
	public int earn;
	public int heal;
	public bool used;


	//constructor for the cards, takes and stores the values
	public Cards (string type, int cost, int health, int attack, int earn, int heal, bool used) {
		this.type = type;
		this.cost = cost;
		this.health = health;
		this.attack = attack;
		this.earn = earn;
		this.heal = heal;
		this.used = used;
	}

}
