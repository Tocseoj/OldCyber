using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCreate : MonoBehaviour {

	public Transform turretContainer;
	public Transform prefabTurret;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2")) {
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Instantiate<Transform> (prefabTurret, new Vector3(mouse.x, mouse.y, 0), Quaternion.identity);
			turretContainer.GetComponent<TurretModification> ().updateArray ();
		} 
	}

	public void DeleteTurret(Turret t) {
		Destroy (t.gameObject);
		turretContainer.GetComponent<TurretModification> ().updateArray ();
	}
}
