using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {

	// Public Var
	public RuntimeAnimatorController idleAnimator;
	public RuntimeAnimatorController weaponAnimator;

	// Private var
	bool weaponOut = false;

	// References
	Animator anim;
	Player_Movement pm;
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
		pm = GetComponent<Player_Movement> ();
		if (pm == null) {
			Debug.LogError ("No Player_Movement Script found on " + gameObject.name);
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("direction", pm.GetDirection ());
		if (Input.GetButtonDown ("Fire2")) {
			if (weaponOut) {
				anim.runtimeAnimatorController = idleAnimator;
				weaponOut = false;
			} else {
				anim.runtimeAnimatorController = weaponAnimator;
				weaponOut = true;
			}
		}
	}
}
