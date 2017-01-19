using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public float knockback = 1;

	public LayerMask layersToHit;
	public Transform player;
	public Transform prefabBulletTrail;

	float timeToFire;

	void Awake() {
		if (player == null) {
			player = (Transform) GameObject.FindGameObjectWithTag ("Player").transform;
		}
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
		RaycastHit2D hit = Physics2D.Raycast (firePoint, transform.right, 10f, layersToHit);
		//Debug.DrawRay (firePoint, transform.right * 100f, Color.yellow);
		if (hit.collider != null) {
			// BAD! NO CHECK IF RIGHT COLLIDER
			hit.collider.transform.GetComponent<Player_Movement>().HitTaken (Damage, transform.right*knockback, hit.point);

			Transform clone = Instantiate<Transform> (prefabBulletTrail, null);
			LineRenderer lr = clone.GetComponent<LineRenderer> ();
			Vector3[] pos = { transform.position, hit.point };
			lr.SetPositions(pos);
			Destroy (clone.gameObject, 0.05f);
			//Debug.DrawLine (firePoint, hit.point, Color.red);
		}
	}
}
