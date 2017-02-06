using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Camera.main.orthographicSize = Screen.height / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
