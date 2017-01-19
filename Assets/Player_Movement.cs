using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public float speedModifier = 5f;
	public float hitStun = 0;

	private Rigidbody2D rigidBody;
	private bool inHitStun = false;

	// Use this for initialization
	void Awake () {
		rigidBody = transform.GetComponent<Rigidbody2D> ();
		if (!rigidBody) Debug.Log("rigidBody not defined!");
	}
	
	void Update() {
		float moveX = Input.GetAxisRaw ("Horizontal");
		float moveY = Input.GetAxisRaw ("Vertical");
		if (!inHitStun) {
			Vector2 moveTo = new Vector2 (moveX * speedModifier, moveY * speedModifier);
			rigidBody.MovePosition (rigidBody.position + moveTo * Time.deltaTime);
			//rigidBody.AddForce(new Vector2(moveX * speedModifier * Time.fixedDeltaTime, moveY * speedModifier * Time.fixedDeltaTime));
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

	public void SetSpeedModifier(float value)
	{  
		speedModifier = value;
	}

	public void SetHitStun(float value)
	{  
		hitStun = value;
	}
}
