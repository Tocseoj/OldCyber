using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour {

	public Transform prefabBullet;

	bool weaponOut = false;
	int direction = 1;
	
	// Update is called once per frame
	void Update () {
		if (weaponOut && Input.GetButtonDown ("Fire1")) {
			Transform clone = Instantiate<Transform> (prefabBullet, transform.position, transform.rotation);
			switch (direction) {
			case 0:
				clone.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 10000);
				break;
			case 1:
				clone.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * -10000);
				break;
			case 2:
				clone.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * -10000);
				break;
			case 3:
				clone.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 10000);
				break;
			default:
				break;
			}
			Destroy (clone.gameObject, 1f);
		}
	}

	void WeaponOut(bool value) {
		weaponOut = value;
	}

	void RecieveDirection (int value) {
		if (value != -1) {
			direction = value;
		}
	}
}
