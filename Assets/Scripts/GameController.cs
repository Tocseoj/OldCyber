using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	int ppu = 8;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log (Screen.height);
		//Camera.main.orthographicSize = (float)Screen.height / 8.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	}

	public void ChangePPU(float _ppu) {
		ppu = (int)_ppu;
	}

	public void ReloadScene() {
		Camera.main.orthographicSize = (float)Screen.height / ppu / 2;
	}
}
