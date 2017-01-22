using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	// Status Effects

	[SerializeField]
	int money = 0;
	int itemCount = 0;
	// Item Array
	[SerializeField]
	int batteries = 0;
	// Weapons

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
