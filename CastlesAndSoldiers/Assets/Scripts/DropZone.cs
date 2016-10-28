using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {


	/*
	 * DropZone class:
	 * Controls the behaviour of the cards' drop zones
	*/


	public Text resultantText;

	public Draggable.Slot typeOfItem = Draggable.Slot.Offense;

	GameObject defensePanel;
	GameObject offensePanel;
	//GameObject[] cardSlot;

	GameObject player;
	PlayerHealth playerHealth;
	PlayerAttack playerAttack;
	PlayerMoney playerMoney;
	Cards cardInfo;

	public Color flashColor = new Color(1f, 0f, 0f, 1f);
	public Color defaultOffenseColor = new Color(1f, 1f, 1f, 1f);
	public Color defaultDefenseColor = new Color(0.984f, 1f, 0.925f, 1f);
	public float flashSpeed = 5f;
	public Image flash;


	void Start () {
		defensePanel = GameObject.FindGameObjectWithTag ("Defense");
		offensePanel = GameObject.FindGameObjectWithTag ("Offense");
		//cardSlot = GameObject.FindGameObjectsWithTag ("Placeholder");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerAttack = player.GetComponent<PlayerAttack> ();
		playerMoney = player.GetComponent<PlayerMoney> ();
	}


	public void OnPointerEnter(PointerEventData eventData){
		if(eventData.pointerDrag == null){
			return;
		}
		//makes the corresponding drop zone change color when the card hovers over it
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			if(typeOfItem == d.typeOfItem){
				if (d.typeOfItem == Draggable.Slot.Offense){
					flash = offensePanel.GetComponent<Image> ();
					flash.color = flashColor;
				} else if (d.typeOfItem == Draggable.Slot.Defense){
					flash = defensePanel.GetComponent<Image>();
					flash.color = flashColor;
				}
				d.placeholderParent = this.transform;
			}
		}
	}


	public void OnPointerExit(PointerEventData eventData){
		if(eventData.pointerDrag == null){
			return;
		}

		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();

		if(d != null && d.placeholderParent == this.transform){
			d.placeholderParent = d.parentToReturnTo;
		}
	}


	//controls the actions performed when player drops the cards in his slots
	public void OnDrop(PointerEventData eventData){
		//Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null){
			if(typeOfItem == d.typeOfItem){
				GameObject g = d.gameObject;
				cardInfo = g.GetComponent<Cards> ();
				if (cardInfo.used == false) {
					if (playerMoney.currentMoney >= cardInfo.cost) {
						playerHealth.currentHealth += cardInfo.health;
						playerHealth.heal += cardInfo.heal;
						playerAttack.attackPoint += cardInfo.attack;
						playerMoney.currentMoney -= cardInfo.cost;
						playerMoney.earn += cardInfo.earn;
						cardInfo.used = true;
						d.parentToReturnTo = this.transform;
					}
				}

				if (d.typeOfItem == Draggable.Slot.Offense){
					flash = offensePanel.GetComponent<Image> ();
					flash.color = defaultOffenseColor;
				} else if (d.typeOfItem == Draggable.Slot.Defense){
					flash = defensePanel.GetComponent<Image>();
					flash.color = defaultDefenseColor;
				}
			}
		}
	}
}


//not working properly. may have to remove; future implementation
	/*void RemoveExtraCard() {
		if (defensePanel.transform.childCount > 6) {
			GameObject temp = cardSlot[Random.Range(0 , cardSlot.Length - 1)] as GameObject;
			//destroy temp
			Destroy(temp);
		}
		if (offensePanel.transform.childCount > 6) {
			GameObject temp = cardSlot[Random.Range(0 , cardSlot.Length - 1)] as GameObject;
			//destroy temp
			Destroy(temp);
		}
	}
 	*/
