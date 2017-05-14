using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

[RequireComponent (typeof (Animator))]
public class PlayerInventory : MonoBehaviour {

	public List<Item> playerItems;
	public List<Item> playerData;

	public float pickupRadius = 10f;
	public LayerMask pickupMask;

	UIController uiGameController;
	Animator animator;

	// Use this for initialization
	void Awake () {
		uiGameController = GameObject.FindObjectOfType<UIController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!animator.GetBool ("pickup") && !animator.GetBool ("search")) {
			if (InputManager.GetButtonDown ("Pickup")) {
				animator.SetBool ("pickup", true);
			}
			if (InputManager.GetButtonDown ("Search")) {
				animator.SetBool ("search", true);
			}
		}
	}

	public bool UseItem(Item.itemType type) {
		Item item = playerItems.Find (x => x.type == type);
		if (item != null) {
			if (--item.quantity <= 0)
				playerItems.Remove (item);
			uiGameController.StartCoroutine ("UpdateInventory");
			return true;
		} else
			return false;
	}

	void Finishedpickup() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, pickupRadius, pickupMask);
		foreach (Collider2D coll in colliders) {
			ItemComponent ic = coll.GetComponent<ItemComponent> ();
			if (ic) {
				if (ic.item.isData)
					playerData.Add (ic.item);
				else {
					Item current = playerItems.Find (x => x.type == ic.item.type);
					if (current != null)
						current.quantity += ic.item.quantity;
					else
						playerItems.Add (ic.item);
				}
				Destroy (ic.gameObject);
			}
		}
		uiGameController.StartCoroutine ("UpdateInventory");
	}
	void Finishedsearch() {
		Debug.Log ("Search Done.");
	}
}
