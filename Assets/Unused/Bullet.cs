using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector3.right * 10f);
	}
}
