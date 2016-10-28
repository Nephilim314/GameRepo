using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour {
	
	
	/*
	 * PlayerMoney class:
	 * Controls the player's money related actions and variables
	*/
	

	public int startingMoney = 10;
	public int currentMoney;

	public int earn = 0;

	Text moneyText;

	Cards cardInfo;


	void Awake () {
		moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<Text> ();
		currentMoney = startingMoney;
	}


	void FixedUpdate () {
		moneyText.text = "Money: " + currentMoney.ToString ();
	}

}
