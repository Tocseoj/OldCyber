using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	static public class PlayerStats
	{
		static int health = 3;
		static int totalHealth = 3;
		static int maxHealth = 30;
		static bool running = false;
		static int money = 2;
		static Transform[] items;
		enum StatusEffects { NONE, BLEED, CRIPPLE, DETOX }
		static int[] crippled;
		static int statusEffect;
		static int heartRate;
		static Transform[] weapons;
		static int equippedWeapon;
		static int energy = 30;
		static int batteries = 3;
		enum AmmoTypes { PISTOL, SHOTGUN, MACHINE, SNIPER }
		static int[] ammo;

		public static bool weaponOut { get; set; }
		public static int dir { get; set; }
	}

	// Use this for initialization
	void Awake () {
		Object.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
