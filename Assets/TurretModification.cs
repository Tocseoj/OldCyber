using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretModification : MonoBehaviour {

	Turret[] turrets;

	void Awake() {
		updateArray ();
	}

	public void updateArray() {
		turrets = GetComponentsInChildren<Turret> ();
	}

	public void SetFireRate(float value)
	{  
		foreach (Turret t in turrets) {
			t.fireRate = value;
		}
	}

	public void SetKnockback(float value)
	{  
		foreach (Turret t in turrets) {
			t.knockback = value;
		}
	}
}
