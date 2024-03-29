﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class Player_Movement : MonoBehaviour {

	// Public Var
	int speedModifier = 1;

	// Private Var
	LinkedList<int> dir = new LinkedList<int>();

	// References
	Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		if (rb == null) {
			Debug.LogError ("No RigidBody2D found on " + gameObject.name);
			this.enabled = false;
		}
		dir.AddLast (-1);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.GetButtonDown ("Up"))
			dir.AddLast (0);
		if (InputManager.GetButtonDown ("Down"))
			dir.AddLast (1);
		if (InputManager.GetButtonDown ("Left"))
			dir.AddLast (2);
		if (InputManager.GetButtonDown ("Right"))
			dir.AddLast (3);

		if (InputManager.GetButtonUp ("Up"))
			dir.Remove (0);
		if (InputManager.GetButtonUp ("Down"))
			dir.Remove (1);
		if (InputManager.GetButtonUp ("Left"))
			dir.Remove (2);
		if (InputManager.GetButtonUp ("Right"))
			dir.Remove (3);

		//if (InputManager.GetButtonDown ("Cancel")) {
		//	dir.Clear ();
		//	dir.AddLast (-1);
		//}

		BroadcastMessage ("RecieveDirection", dir.Last.Value);
	}

	void OnApplicationFocus( bool hasFocus )
	{
		if (!hasFocus) {
			dir.Clear ();
			dir.AddLast (-1);
		}
	}

	void FixedUpdate() {
		switch (dir.Last.Value)
		{
		case 0:
			rb.MovePosition (new Vector2 (transform.position.x, transform.position.y + speedModifier));
			break;
		case 1:
			rb.MovePosition (new Vector2 (transform.position.x, transform.position.y - speedModifier));
			break;
		case 2:
			rb.MovePosition (new Vector2 (transform.position.x - speedModifier, transform.position.y));
			break;
		case 3:
			rb.MovePosition (new Vector2 (transform.position.x + speedModifier, transform.position.y));
			break;
		default:
			break;
		}
	}
}
