using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {

	// Public Var
	public RuntimeAnimatorController idleAnimator;
	public RuntimeAnimatorController weaponAnimator;

	// Private var
	bool weaponOut = false;
	int direction;

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
		if (GameController.PlayerStats.weaponOut) {
			anim.runtimeAnimatorController = idleAnimator;
		} else {
			anim.runtimeAnimatorController = weaponAnimator;
		}
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("direction", direction);
		if (Input.GetButtonDown ("Fire2")) {
			if (weaponOut) {
				anim.runtimeAnimatorController = idleAnimator;
				weaponOut = false;
				SendMessage ("WeaponOut", weaponOut);
			} else {
				anim.runtimeAnimatorController = weaponAnimator;
				weaponOut = true;
				SendMessage ("WeaponOut", weaponOut);
			}
			GameController.PlayerStats.weaponOut = weaponOut;
		}
	}

	void RecieveDirection (int value) {
		direction = value;
	}
}
