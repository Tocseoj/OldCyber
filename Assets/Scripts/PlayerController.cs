using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
public class PlayerController : MonoBehaviour {

	// a Stack-like list to save current direction key down
	LinkedList<int> direction;
	// Rigidbody2D attached to the player;
	Rigidbody2D rigidBody;
	// Animator attached to the player
	Animator animator;
	// Amount of pixels moved by rigidbody.MoveDirection in current direction
	public int speed = 1;

	void Awake () {
		direction = new LinkedList<int> ();
		direction.AddLast (-1);

		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// checks every frame if a movement button has been
	// pressed or released. Then it updates the LinkedList.
	void Update () {
		if (InputManager.GetButtonDown ("Right"))
			direction.AddLast (0);
		if (InputManager.GetButtonDown ("Up"))
			direction.AddLast (1);
		if (InputManager.GetButtonDown ("Left"))
			direction.AddLast (2);
		if (InputManager.GetButtonDown ("Down"))
			direction.AddLast (3);
		
		if (InputManager.GetButtonUp ("Right"))
			direction.Remove (0);
		if (InputManager.GetButtonUp ("Up"))
			direction.Remove (1);
		if (InputManager.GetButtonUp ("Left"))
			direction.Remove (2);
		if (InputManager.GetButtonUp ("Down"))
			direction.Remove (3);

		// Updates animator parameters
		if (direction.Last.Value != -1 && !animator.GetBool("pickup") && !animator.GetBool("search")) {
			animator.SetInteger ("direction", direction.Last.Value);
			animator.SetBool("moving", true);
		} else {
			animator.SetBool("moving", false);
		}
	}

	// use fixedUpdate to move rigibodies
	void FixedUpdate() {
		if (!animator.GetBool ("moving"))
			return;

		Vector2 moveTo = rigidBody.position;
		switch (direction.Last.Value) {
		case 0:
			moveTo.x += speed;
			break;
		case 1:
			moveTo.y += speed;
			break;
		case 2:
			moveTo.x -= speed;
			break;
		case 3:
			moveTo.y -= speed;
			break;
		default:
			break;
		}
		rigidBody.MovePosition (moveTo);
	}

	// fixes movement glitches when game is clicked offscreen
	// TODO: do it on game pause as well
	void OnApplicationFocus(bool hasFocus) {
		if (!hasFocus) {
			direction.Clear ();
			direction.AddLast (-1);
		}
	}
}
