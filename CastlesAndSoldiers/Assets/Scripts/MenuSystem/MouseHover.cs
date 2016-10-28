using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseHover : MonoBehaviour {

	void Start () {
		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseEnter()
	{
		GetComponent<Renderer> ().material.color = Color.black;
	}
	
	void OnMouseExit()
	{
		GetComponent<Renderer> ().material.color = Color.white;
	}
}
