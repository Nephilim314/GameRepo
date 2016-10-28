using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyMoney : MonoBehaviour {
	
	
	/*
	 * EnemyMoney class:
	 * Controls the enemy's money related actions and variables
	*/
	

	public int startingMoney = 50;
	public int currentMoney;
	public int earn = 0;

	Text moneyText;
	
	Cards cardInfo;
	

	void Awake () {
		moneyText = GameObject.FindGameObjectWithTag("EnemyMoneyText").GetComponent<Text> ();
		currentMoney = startingMoney;
	}
	

	void FixedUpdate () {
		moneyText.text = "Money: " + currentMoney.ToString ();
	}
	
}