using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {

	// References
	Animator anim;
	Player_Movement pm;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		if (anim == null) {
			Debug.LogError ("No Animator found on " + gameObject.name);
			this.enabled = false;
		}
		pm = GetComponent<Player_Movement> ();
		if (pm == null) {
			Debug.LogError ("No Player_Movement Script found on " + gameObject.name);
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("direction", pm.GetDirection ());
	}
}
