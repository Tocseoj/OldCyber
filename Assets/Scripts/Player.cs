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
}
