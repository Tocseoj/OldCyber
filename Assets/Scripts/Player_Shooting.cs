using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour {

	public Transform prefabBullet;

	bool weaponOut = false;
	int direction = 1;
	int accuracy = 1;

	void Awake() {
		if (prefabBullet == null) {
			Debug.LogError ("No Bullet Prefab found on " + gameObject.name);
			this.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (weaponOut && TeamUtility.IO.InputManager.GetButtonDown ("Fire")) {
			Transform clone = Instantiate<Transform> (prefabBullet, transform.position, transform.rotation);
			switch (direction) {
			case 0:
				clone.Rotate (new Vector3 (0, 0, 90 + Random.Range(-accuracy, accuracy)));
				break;
			case 1:
				clone.Rotate (new Vector3 (0, 0, 270 + Random.Range(-accuracy, accuracy)));
				break;
			case 2:
				clone.Rotate (new Vector3 (0, 0, 180 + Random.Range(-accuracy, accuracy)));
				break;
			case 3:
				clone.Rotate (new Vector3 (0, 0, 0 + Random.Range(-accuracy, accuracy)));
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
			accuracy = 5;
		} else {
			accuracy = 1;
		}
	}
}
