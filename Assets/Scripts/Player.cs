﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class Player : MonoBehaviour {

	[SerializeField]
	int health_current = 3;
	int health_total = 3;
	const int health_maximum = 33;
	[SerializeField]
	int energy = 33;
	int maxEnergy = 33;

	[SerializeField]
	int heartRate = 0;
	[SerializeField]
	int speed = 1;
	// Status Effects

	[SerializeField]
	int money = 0;
	int itemCount = 0;
	// Item Array
	[SerializeField]
	int batteries = 0;
	// Weapons

	LinkedList<int> dir = new LinkedList<int>();
	Rigidbody2D rb;
	Animator anim;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		if (rb == null) {
			Debug.LogError ("No RigidBody2D found on " + gameObject.name);
			this.enabled = false;
		}
		anim = GetComponent<Animator> ();
		if (anim == null) {
			Debug.LogError ("No Animator found on " + gameObject.name);
			this.enabled = false;
		}

		dir.AddLast (-1);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.GetButtonDown ("Right"))
			dir.AddLast (0);
		if (InputManager.GetButtonDown ("Up"))
			dir.AddLast (1);
		if (InputManager.GetButtonDown ("Left"))
			dir.AddLast (2);
		if (InputManager.GetButtonDown ("Down"))
			dir.AddLast (3);

		if (InputManager.GetButtonUp ("Right"))
			dir.Remove (0);
		if (InputManager.GetButtonUp ("Up"))
			dir.Remove (1);
		if (InputManager.GetButtonUp ("Left"))
			dir.Remove (2);
		if (InputManager.GetButtonUp ("Down"))
			dir.Remove (3);

		if (anim.GetBool("pickup"))
			return;

		if (dir.Last.Value == -1) {
			anim.SetBool ("moving", false);
		} else {
			anim.SetBool ("moving", true);
			anim.SetInteger ("direction", dir.Last.Value);
		}

		if (InputManager.GetButtonDown ("Fire")) {
			anim.SetBool ("moving", false);
			anim.SetBool ("pickup", true);
		}
		if (InputManager.GetKey (KeyCode.E)) {
			anim.SetBool ("moving", false);
			anim.SetBool ("search", true);
		}
	}
	void OnApplicationFocus( bool hasFocus )
	{
		if (!hasFocus) {
			dir.Clear ();
			dir.AddLast (-1);
		} 
	}

	void FixedUpdate() {
		if (!anim.GetBool ("moving")) {
			return;
		}

		if (dir.Last.Value == 0)
			rb.MovePosition (new Vector2 (rb.position.x + speed, rb.position.y));
		if (dir.Last.Value == 1)
			rb.MovePosition (new Vector2 (rb.position.x, rb.position.y + speed));
		if (dir.Last.Value == 2)
			rb.MovePosition (new Vector2 (rb.position.x - speed, rb.position.y));
		if (dir.Last.Value == 3)
			rb.MovePosition (new Vector2 (rb.position.x, rb.position.y - speed));
	}

	// ******************** //

	public int Health_current {
		get {
			return this.health_current;
		}
		set {
			health_current = value;
		}
	}

	public int Health_total {
		get {
			return this.health_total;
		}
		set {
			health_total = value;
		}
	}

	public int Energy {
		get {
			return this.energy;
		}
		set {
			energy = value;
		}
	}

	public int MaxEnergy {
		get {
			return this.maxEnergy;
		}
		set {
			maxEnergy = value;
		}
	}

	public int HeartRate {
		get {
			return this.heartRate;
		}
		set {
			heartRate = value;
		}
	}

	public int Money {
		get {
			return this.money;
		}
		set {
			money = value;
		}
	}

	public int ItemCount {
		get {
			return this.itemCount;
		}
		set {
			itemCount = value;
		}
	}

	public int Batteries {
		get {
			return this.batteries;
		}
		set {
			batteries = value;
		}
	}
}
