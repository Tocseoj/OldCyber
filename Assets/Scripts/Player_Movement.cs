using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		if (Input.GetButtonDown ("Up"))
			dir.AddLast (0);
		if (Input.GetButtonDown ("Down"))
			dir.AddLast (1);
		if (Input.GetButtonDown ("Left"))
			dir.AddLast (2);
		if (Input.GetButtonDown ("Right"))
			dir.AddLast (3);

		if (Input.GetButtonUp ("Up"))
			dir.Remove (0);
		if (Input.GetButtonUp ("Down"))
			dir.Remove (1);
		if (Input.GetButtonUp ("Left"))
			dir.Remove (2);
		if (Input.GetButtonUp ("Right"))
			dir.Remove (3);

		if (Input.GetButtonDown ("Cancel")) {
			dir.Clear ();
			dir.AddLast (-1);
		}

		BroadcastMessage ("RecieveDirection", dir.Last.Value);
		GameController.PlayerStats.dir = dir.Last.Value;
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
