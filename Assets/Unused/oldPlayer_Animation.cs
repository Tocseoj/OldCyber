using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {

	// Public Var
	public RuntimeAnimatorController idleAnimator;
	public RuntimeAnimatorController weaponAnimator;

	// Private var
	bool weaponOut = false;
	int direction = 1;

	// References
	Animator anim;

	// Use this for initialization
	void Awake () {
		if (weaponAnimator == null) {
			Debug.Log ("No RuntimeWeaponAnimator found on " + gameObject.name);
			this.enabled = false;
		}
		if (idleAnimator == null) {
			Debug.Log ("No RuntimeIdleAnimator found on " + gameObject.name);
			this.enabled = false;
		}
		anim = GetComponent<Animator> ();
		if (anim == null) {
			Debug.LogError ("No Animator found on " + gameObject.name);
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("direction", direction);
		if (TeamUtility.IO.InputManager.GetButtonDown ("Swap")) {
			if (weaponOut) {
				anim.runtimeAnimatorController = idleAnimator;
				weaponOut = false;
				SendMessage ("WeaponOut", weaponOut);
			} else {
				anim.runtimeAnimatorController = weaponAnimator;
				weaponOut = true;
				SendMessage ("WeaponOut", weaponOut);
			}
		}
	}

	void RecieveDirection (int value) {
		direction = value;
	}
}
