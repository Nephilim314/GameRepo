using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public bool isStart;
	public bool isOptions;
	public bool isExit;
	public AudioClip startGame;

	private AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	void OnMouseUp()
	{
		if(isStart)
		{
			Application.LoadLevel(1);
			GetComponent<Renderer> ().material.color = Color.green;
			source.Play();

		}
		if(isOptions)
		{
			Application.LoadLevel(2);
			GetComponent<Renderer> ().material.color = Color.green;

		}
		if(isExit)
		{
			Application.Quit();
			GetComponent<Renderer> ().material.color = Color.green;

		}
	}

}
