using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class PlayerCombat : MonoBehaviour {

	public Transform firepoint;
	public Bullet prefabBullet;

	public float timeToShoot = 1f;
	float lastShot = 0f;

	PlayerInventory inventory;
	Animator animator;

	void Awake () {
		inventory = GetComponent<PlayerInventory> ();
		animator = GetComponent<Animator> ();
	}
	
	void Update () {
		if (!animator.GetBool ("pickup") && !animator.GetBool ("search")) {
			if (InputManager.GetButton ("Fire")) {
				if (Time.time - lastShot >= timeToShoot) {
					StartCoroutine ("Shoot");
					lastShot = Time.time;
				}
			}
		}
	}

	IEnumerator Shoot() {
		if (inventory.UseItem (Item.itemType.Ammo)) {
			// Successful shot
			firepoint.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, GetComponent<Animator> ().GetInteger ("direction") * 90));
			firepoint.transform.Translate (6, -2, 0, Space.Self);
			firepoint.gameObject.SetActive (true);
			Bullet clone = Instantiate<Bullet> (prefabBullet, firepoint.transform.position, firepoint.transform.rotation);
			clone.transform.Translate (new Vector3 (16, 1, 0), Space.Self);
			clone.speed = 10;
			yield return new WaitForSeconds (0.1f);
			firepoint.gameObject.SetActive (false);
			firepoint.transform.localPosition = new Vector3 (0, 0, 0);
		}
	}
}
