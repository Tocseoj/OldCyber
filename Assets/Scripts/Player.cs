using System.Collections;
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
	// Item Array
	public List<string> items = new List<string>();
	public List<int> itemCount = new List<int>();
	public List<string> data = new List<string>();
	[SerializeField]
	int batteries = 0;
	// Weapons

	[SerializeField]
	float pickupRadius = 10f;
	public LayerMask itemLayerMask;

	LinkedList<int> dir = new LinkedList<int>();
	Rigidbody2D rb;
	Animator anim;
	GameController gameController;
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
		GameObject controller = GameObject.FindWithTag ("GameController");
		if (controller == null) {
			Debug.LogError ("No GameController found");
		}
		gameController = controller.GetComponent<GameController> ();

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

		if (anim.GetBool("pickup") || anim.GetBool("search"))
			return;

		if (dir.Last.Value == -1) {
			anim.SetBool ("moving", false);
		} else {
			anim.SetBool ("moving", true);
			anim.SetInteger ("direction", dir.Last.Value);
		}

		if (InputManager.GetButtonDown ("Pickup")) {
			anim.SetBool ("moving", false);
			anim.SetBool ("pickup", true);
		}
		if (InputManager.GetButtonDown ("Search")) {
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

	void Finishedpickup() {
		Collider2D[] nearItems = Physics2D.OverlapCircleAll (new Vector2(transform.position.x, transform.position.y - 4), pickupRadius, itemLayerMask);
		foreach (Collider2D coll in nearItems) {
			if (coll.tag.StartsWith ("Book")) {
				data.Add (coll.tag);
				Destroy (coll.gameObject);
				gameController.StartCoroutine ("UpdateData");
			} else {
				int index = items.IndexOf (coll.tag);
				if (index == -1) {
					items.Add (coll.tag);
					if (itemCount.Count < items.Count)
						itemCount.AddRange (new int[items.Count - itemCount.Count]);
					;
					itemCount [items.Count - 1] += 1;
				} else {
					itemCount [index] += 1;
				}
				Destroy (coll.gameObject);
				gameController.StartCoroutine ("UpdateInventory");
			}
		}
	}

	void Finishedsearch() {
		
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

	public int Batteries {
		get {
			return this.batteries;
		}
		set {
			batteries = value;
		}
	}
}
