using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {

	public Sprite[] muzzleFlashes;
	int cursor = 0;

	// Use this for initialization
	void OnEnable () {
		if (muzzleFlashes.Length == 0)
			return;
		if (++cursor >= muzzleFlashes.Length)
			cursor = 0;
		GetComponent<SpriteRenderer> ().sprite = muzzleFlashes [cursor];
	}
}
