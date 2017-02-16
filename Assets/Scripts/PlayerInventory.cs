using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class PlayerInventory : MonoBehaviour {

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
		if (TeamUtility.IO.InputManager.GetKey (KeyCode.Space)) {
			GetComponent<Animator> ().SetBool ("pickup", true);
		}
		if (TeamUtility.IO.InputManager.GetKey (KeyCode.E)) {
			GetComponent<Animator> ().SetBool ("search", true);
		}
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
