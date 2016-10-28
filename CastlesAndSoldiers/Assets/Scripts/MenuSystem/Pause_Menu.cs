using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour {

	public GameObject PauseMenu;
	private bool paused = false;

	Button resume;
	Button restart;
	Button mainMenu;
	Button exit;


	void Start() {
		PauseMenu.SetActive (false);
	}


	void Update(){
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}
		if (paused) {
			PauseMenu.SetActive(true);
			Time.timeScale = 0;
		}
		if (!paused) {
			PauseMenu.SetActive(false);
			Time.timeScale = 1;
		}
	}
}
