using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {


	/*
	 * Draggable class:
	 * Controls the draggable behaviour of the cards
	*/


	public static GameObject itemBeingDragged;
	Vector3 startposition;
	Transform startParent;
	TurnController turnController;

	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;
	
	public enum Slot {Offense, Defense, Both};
	public Slot typeOfItem = Slot.Offense;


	public void Start() {
		GameObject gameHandler = GameObject.Find ("_GameHandler");
		if (gameHandler != null)
			turnController = gameHandler.GetComponent<TurnController> ();

	}


	public void OnBeginDrag(PointerEventData eventData){
		if(turnController != null && turnController.playerTurn != 1 ){
			return;
		}

		itemBeingDragged = gameObject;
		startposition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;


		placeholder = new GameObject ();
		placeholder.transform.SetParent ( this.transform.parent );
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex());

		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}


	public void OnDrag(PointerEventData eventData){
		transform.position = Input.mousePosition;

		this.transform.position = eventData.position;

		if (placeholder.transform.parent != placeholderParent) {
			placeholder.transform.SetParent(placeholderParent);
		}

		int newSiblingIndex = placeholderParent.childCount;

		for(int i = 0; i < placeholderParent.childCount; i++){
			if(this.transform.position.x < placeholderParent.GetChild(i).position.x){

				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex){
					newSiblingIndex--;
				}

				break;
			}
		}

		placeholder.transform.SetSiblingIndex (newSiblingIndex);
	}


	public void OnEndDrag(PointerEventData eventData){
		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent = startParent) {
			transform.position = startposition;
		}

		this.transform.SetParent (parentToReturnTo);
		this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex());

		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		Destroy (placeholder);
	}

}

