using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public RectTransform prefabGridView;
	public RectTransform prefabListView;

	Player playerScript;
	RectTransform menu;

	// ** UI ** //

	// Menu
	bool inventoryIsOpen = false;
	int currentTab = 2;
	bool itemsGridView = true;
	bool dataGridView = false;
	int[] activeItemIndicies = { -1, -1, -1};
	int activeDataIndex = -1;

	// ******** //

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		//Debug.Log (Screen.height);
		//Camera.main.orthographicSize = (float)Screen.height / 8.0f;

		GameObject temp = GameObject.FindGameObjectWithTag ("Player");
		if (temp != null) {
			playerScript = temp.GetComponent<Player> ();
			if (playerScript == null) {
				Debug.LogError ("No Player Script found on " + temp.name);
			}
		} else
			Debug.LogError ("No Player GameObject found.");
		temp = GameObject.FindGameObjectWithTag ("Menu");
		if (temp != null) {
			menu = temp.GetComponent<RectTransform> ();
			if (menu == null) {
				Debug.LogError ("No Menu found on " + temp.name);
			}
		} else
			Debug.LogError ("No Menu GameObject found.");

		if (prefabGridView == null) {
			Debug.LogError ("No Grid Prefab found on " + gameObject.name);
		}
		if (prefabListView == null) {
			Debug.LogError ("No List Prefab found on " + gameObject.name);
		}

		StartCoroutine(UpdateInventory ());
		StartCoroutine(UpdateData ());
		menu.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			if (inventoryIsOpen) {
				inventoryIsOpen = !inventoryIsOpen;
				menu.gameObject.SetActive (false);
			} else {
				inventoryIsOpen = !inventoryIsOpen;
				menu.gameObject.SetActive (true);
			}
		}
	}

	public IEnumerator UpdateInventory() {
		RectTransform itemContainer = (RectTransform) menu.FindChild ("InventoryFrame/ItemsView/Viewport/ItemContent");
		for (int i = 0; i < itemContainer.childCount; i++) {
			Destroy (itemContainer.GetChild (i).gameObject);
		}
		if (itemsGridView) {
			int rows = (playerScript.items.Count / 5) + 1;
			int itemsInLastRow = playerScript.items.Count % 5;
			if (itemsInLastRow == 0)
				rows -= 1;
			itemContainer.sizeDelta = new Vector2 (itemContainer.sizeDelta.x, (rows * 19) + 3);
			RectTransform clone = null;
			int cursor = 0;
			for (int i = 0; i < rows; i++) {
				clone = Instantiate<RectTransform> (prefabGridView);
				clone.SetParent (itemContainer, false);
				clone.anchoredPosition = new Vector2 (clone.anchoredPosition.x, clone.anchoredPosition.y - (19 * i));
				for (int j = 0; j < 5; j++) {
					Transform iBox = clone.Find ("Item_" + j);
					if (iBox) {
						Image img = iBox.GetChild(0).GetComponent<Image>();
						if (cursor < playerScript.items.Count)
							img.sprite = GetComponent<Items> ().UI_itemSprites [Items.getID (playerScript.items [cursor++])];
					}	
				}
			}
			for (int j = 4; itemsInLastRow != 0 && j >= itemsInLastRow; j--) {
				if (clone) {
					Transform iBox = clone.FindChild ("Item_" + j);
					if (iBox)
						Destroy (iBox.gameObject);
				}
			}
		} else {
			int rows = playerScript.items.Count;
			itemContainer.sizeDelta = new Vector2 (itemContainer.sizeDelta.x, rows * 19);
			RectTransform clone = null;
			for (int i = 0; i < rows; i++) {
				clone = Instantiate<RectTransform> (prefabListView);
				clone.SetParent (itemContainer, false);
				clone.anchoredPosition = new Vector2 (clone.anchoredPosition.x, clone.anchoredPosition.y - (19 * i));
				Image img = clone.GetChild(0).GetComponent<Image>();
				img.sprite = GetComponent<Items> ().UI_itemSprites [Items.getID (playerScript.items [i])];
			}
		}
		yield return null;
	}

	public IEnumerator UpdateData() {
		RectTransform dataContainer = (RectTransform) menu.FindChild ("InventoryFrame/DataView/Viewport/DataContent");
		for (int i = 0; i < dataContainer.childCount; i++) {
			Destroy (dataContainer.GetChild (i).gameObject);
		}
		if (dataGridView) {
			int rows = (playerScript.data.Count / 5) + 1;
			int itemsInLastRow = playerScript.data.Count % 5;
			if (itemsInLastRow == 0)
				rows -= 1;
			dataContainer.sizeDelta = new Vector2 (dataContainer.sizeDelta.x, (rows * 19) + 3);
			RectTransform clone = null;
			for (int i = 0; i < rows; i++) {
				clone = Instantiate<RectTransform> (prefabGridView);
				clone.SetParent (dataContainer, false);
				clone.anchoredPosition = new Vector2 (clone.anchoredPosition.x, clone.anchoredPosition.y - (19 * i));
				for (int j = 0; j < 5; j++) {
					if (i == rows - 1 && itemsInLastRow != 0 && j >= itemsInLastRow)
						break;
					Transform iBox = clone.Find ("Item_" + j);
					if (iBox) {
//						Image img = Instantiate<Image> ();
//						img.rectTransform.SetParent (iBox, false);
//						img.sprite = GetComponent<Items> ().UI_itemSprites [Items.getID (playerScript.data [5 * i + j])];
					}
				}
			}
			for (int j = 4; itemsInLastRow != 0 && j >= itemsInLastRow; j--) {
				if (clone) {
					Transform iBox = clone.FindChild ("Item_" + j);
					if (iBox)
						Destroy (iBox.gameObject);
				}
			}
		} else {
			int rows = playerScript.data.Count;
			dataContainer.sizeDelta = new Vector2 (dataContainer.sizeDelta.x, rows * 19);
			RectTransform clone = null;
			for (int i = 0; i < rows; i++) {
				clone = Instantiate<RectTransform> (prefabListView);
				clone.SetParent (dataContainer, false);
				clone.anchoredPosition = new Vector2 (clone.anchoredPosition.x, clone.anchoredPosition.y - (19 * i));
//				Image img = Instantiate<Image> ();
//				img.rectTransform.SetParent (clone, false);
//				img.sprite = GetComponent<Items> ().UI_itemSprites [Items.getID (playerScript.items [i])];
			}
		}
		yield return null;
	}
		
	public void OrganizerItemViewClick(bool isGridView) {
		itemsGridView = isGridView;
		if (itemsGridView) {
			Transform temp = menu.FindChild ("InventoryFrame/OrganizerListItems");
			temp.GetComponent<Button> ().interactable = true;
			temp.GetComponent<Button> ().Select ();
			temp = menu.FindChild ("InventoryFrame/OrganizerGridItems");
			temp.GetComponent<Button> ().interactable = false;
		} else {
			Transform temp = menu.FindChild ("InventoryFrame/OrganizerGridItems");
			temp.GetComponent<Button> ().interactable = true;
			temp.GetComponent<Button> ().Select ();
			temp = menu.FindChild ("InventoryFrame/OrganizerListItems");
			temp.GetComponent<Button> ().interactable = false;
		}
		StartCoroutine(UpdateInventory ());
	}

	public void OrganizerDataViewClick(bool isGridView) {
		dataGridView = isGridView;
		if (dataGridView) {
			Transform temp = menu.FindChild ("InventoryFrame/OrganizerListData");
			temp.GetComponent<Button> ().interactable = true;
			temp = menu.FindChild ("InventoryFrame/OrganizerGridData");
			temp.GetComponent<Button> ().interactable = false;
		} else {
			Transform temp = menu.FindChild ("InventoryFrame/OrganizerGridData");
			temp.GetComponent<Button> ().interactable = true;
			temp = menu.FindChild ("InventoryFrame/OrganizerListData");
			temp.GetComponent<Button> ().interactable = false;
		}
		StartCoroutine(UpdateData ());
	}
}
