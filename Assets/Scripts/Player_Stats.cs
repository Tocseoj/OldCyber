using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

	public int health = 3;
	public int totalHealth = 3;
	public  int maxHealth = 30;
	public bool running = false;
	public int money = 2;
	public Transform[] items;
	enum StatusEffects { NONE, BLEED, CRIPPLE, DETOX }
	public int[] crippled;
	public int statusEffect;
	public int heartRate;
	public Transform[] weapons;
	public int equippedWeapon;
	public int energy = 30;
	public int batteries = 3;
	enum AmmoTypes { PISTOL, SHOTGUN, MACHINE, SNIPER }
	public int[] ammo;
	public bool weaponOut;
	public int dir;

}
