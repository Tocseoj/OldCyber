using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public float knockback = 1;

	public LayerMask toHit;
	public Transform player;

	float timeToFire;

	void Awake() {
		timeToFire = Random.value;
	}

	// Update is called once per frame
	void Update () {
		transform.right = player.position - transform.position;

		if (fireRate != 0 && Time.time > timeToFire) {
			timeToFire = Time.time + 1/(fireRate + Random.Range(-0.1f, 0.1f));
			Shoot ();
		}
	}

	void Shoot() {
		Vector2 firePoint = new Vector2 (transform.position.x, transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePoint, transform.right, 100f, toHit);
		Debug.DrawRay (firePoint, transform.right * 100f, Color.yellow);
		if (hit.collider != null) {
			Debug.DrawLine (firePoint, hit.point, Color.red);
			hit.rigidbody.AddForceAtPosition (transform.right * knockback, hit.point);
		}
	}
}
