using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

[RequireComponent (typeof (Animator))]
public class PlayerInventory : MonoBehaviour {

	public Transform firepoint;
	public Bullet prefabBullet;

	public float timeToShoot = 1f;
	float lastShot = 0f;

	public List<Item> playerItems;
	public List<Item> playerData;

	public float pickupRadius = 10f;
	public LayerMask pickupMask;

	UIController uiGameController;

	// Use this for initialization
	void Awake () {
		uiGameController = GameObject.FindWithTag ("GameController").GetComponent<UIController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.GetButtonDown ("Pickup")) {
			GetComponent<Animator> ().SetBool ("pickup", true);
		}
		if (InputManager.GetButtonDown ("Search")) {
			GetComponent<Animator> ().SetBool ("search", true);
		}
		if (InputManager.GetButton ("Fire")) {
			if (Time.time - lastShot >= timeToShoot) {
				StartCoroutine ("Shoot");
				lastShot = Time.time;
			}
		}
	}

	IEnumerator Shoot() {
		SpriteRenderer spr = firepoint.FindChild("MuzzleFlash_" + GetComponent<Animator>().GetInteger("direction")).GetComponent<SpriteRenderer>();
		spr.gameObject.SetActive(true);
		Bullet clone = Instantiate<Bullet> (prefabBullet, spr.transform.position, spr.transform.rotation);
		clone.transform.Translate (new Vector3(16, 1, 0), Space.Self);
		clone.speed = 10;
		yield return new WaitForSeconds(0.1f);
		spr.gameObject.SetActive(false);
	}

	void Finishedpickup() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, pickupRadius, pickupMask);
		foreach (Collider2D coll in colliders) {
			Item item = coll.GetComponent<Item> ();
			if (item) {
				if (item.isData)
					playerData.Add (item);
				else
					playerItems.Add (item);
				Destroy (item.gameObject);
			}
		}
		uiGameController.StartCoroutine ("UpdateInventory");
	}
	void Finishedsearch() {
		Debug.Log ("Search Done.");
	}
}
