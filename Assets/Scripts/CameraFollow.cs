using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform FollowTarget;
	public float smoothing = 0;

	// Use this for initialization
	void Awake () {
		if (FollowTarget == null) {
			Debug.LogError ("No Target found on " + gameObject.name);
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 toPosition = new Vector3 (FollowTarget.position.x, FollowTarget.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, toPosition, smoothing * Time.smoothDeltaTime);

	}
}
