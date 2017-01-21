using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour {

	public int speedModifier = 5;
	public float hitStun = 0;

	private Rigidbody2D rigidBody;
	private bool inHitStun = false;
	private bool lastMoveX = false;

	// Use this for initialization
	void Awake () {
		rigidBody = transform.GetComponent<Rigidbody2D> ();
		if (!rigidBody) Debug.Log("rigidBody not defined!");
	}
	
	void FixedUpdate() {
		int moveX = (int) Input.GetAxis ("Horizontal");
		int moveY = (int) Input.GetAxis ("Vertical");


		if (!inHitStun) {
			Vector2 moveTo = Vector2.zero;
			if ((moveX != 0) && !(lastMoveX && (moveY != 0))) {
				moveTo = new Vector2 (moveX * speedModifier, 0);
				lastMoveX = true;
			} else if (moveY != 0) {
				moveTo = new Vector2 (0, moveY * speedModifier);
				lastMoveX = false;
			}
			rigidBody.MovePosition (rigidBody.position + moveTo);
		}
	}

	public void HitTaken(float damage, Vector2 knockback, Vector2 point) {
		if (!inHitStun)
			StartCoroutine ("HitStun");
		rigidBody.AddForceAtPosition (knockback, point);
	}

	IEnumerator HitStun() {
		inHitStun = true;
		yield return new WaitForSeconds(hitStun);
		inHitStun = false;
	}

	public void SetSpeedModifier(int value)
	{  
		speedModifier = value;
	}

	public void SetHitStun(float value)
	{  
		hitStun = value;
	}
}
