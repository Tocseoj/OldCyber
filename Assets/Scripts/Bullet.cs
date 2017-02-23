using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int speed = 10;
	public Sprite[] bulletSprites;

	// Use this for initialization
	void Awake () {
		transform.position = new Vector3 (Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
		Destroy (gameObject, 10f);
		if (bulletSprites.Length == 0)
			return;
		GetComponent<SpriteRenderer> ().sprite = bulletSprites [Random.Range(0, bulletSprites.Length)];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector3.right * speed);
	}
}
