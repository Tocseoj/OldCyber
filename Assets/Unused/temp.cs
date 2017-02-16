using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (TeamUtility.IO.InputManager.GetKeyDown(KeyCode.Alpha1))
			GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled ;
	}
}
