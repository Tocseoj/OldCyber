using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public float speedModifier = 0.1f;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Awake () {
		rigidBody = transform.GetComponent<Rigidbody2D> ();
		if (!rigidBody) Debug.Log("rigidBody not defined!");
	}
	
	void FixedUpdate() {
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		//Vector2 moveTo = new Vector2 (moveX * speedModifier, moveY * speedModifier);
		//rigidBody.MovePosition (rigidBody.position + moveTo * Time.fixedDeltaTime);
		rigidBody.AddForce(new Vector2(moveX * speedModifier * Time.fixedDeltaTime, moveY * speedModifier * Time.fixedDeltaTime));
	}
}
