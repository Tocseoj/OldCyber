using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public PlayerInventory playerInventory;
	[Space]

	public Sprite[] iconsUI;

	// UI elements that need changed by script
	[Header("UI References")]
	public RectTransform menu;
	public RectTransform itemContainer;
	public RectTransform dataContainer;
	public Button itemsOrganizerGrid;
	public Button itemsOrganizerList;
	public Button dataOrganizerGrid;
	public Button dataOrganizerList;

	// prefabs for generating Inventory
	public RectTransform prefabGridView;
	public RectTransform prefabListView;

	// booleans containing state of UI elements
	bool isMenuOpen = false;
	bool isGridViewItems = true;
	bool isGridViewData = false;

	// Use this for initialization
	void Awake () {
		if (menu == null || itemContainer == null || dataContainer == null || itemsOrganizerGrid == null ||
		    itemsOrganizerList == null || dataOrganizerGrid == null || dataOrganizerList == null) {
			Debug.LogError ("Insufficient UI components attached to " + gameObject.name);
			this.enabled = false;
		}

		if (playerInventory == null) {
			Debug.LogError ("No Player Inventory attached to (UIController) on " + gameObject.name);
		}

		UpdateItems ();
		UpdateData ();
		menu.gameObject.SetActive (isMenuOpen);
	}
	
	// Update is called once per frame
	void Update () {
		if (TeamUtility.IO.InputManager.GetKeyDown (KeyCode.I))
			ToggleInventory (); 
	}

	void ToggleInventory() {
		isMenuOpen = !isMenuOpen;
		menu.gameObject.SetActive (isMenuOpen);
	}

	// Coroutine to redraw inventory containers
	public IEnumerator UpdateInventory() {
		UpdateItems ();
		UpdateData ();
		yield return null;
	}

	void UpdateItems() {
		// Clear items
		for (int i = 0; i < itemContainer.childCount; i++)
			Destroy (itemContainer.GetChild (i).gameObject);
		// Instantiate new UI elements
		int rows = isGridViewItems ? playerInventory.playerItems.Count / 5 + 1 : playerInventory.playerItems.Count;
		if (isGridViewItems && playerInventory.playerItems.Count % 5 == 0)
			rows -= 1;
		itemContainer.sizeDelta = new Vector2(itemContainer.sizeDelta.x, rows * 19 + 3);
		RectTransform clone = null;
		for (int i = 0; i < rows; i++) {
			clone = Instantiate<RectTransform> (isGridViewItems ? prefabGridView : prefabListView);
			clone.SetParent (itemContainer, false);
			clone.anchoredPosition = new Vector2 (clone.anchoredPosition.x, -(19 * i));
			// set icons
			if (isGridViewItems) {
				for (int j = 0; j < 5 && (i * 5 + j) < playerInventory.playerItems.Count; j++) {
					Image img = clone.GetChild (j).GetChild (0).GetComponent<Image> ();
					img.sprite = iconsUI [(int)playerInventory.playerItems [i * 5 + j].type];
				}
			} else {
				Image img = clone.GetChild (0).GetComponent<Image> ();
				img.sprite = iconsUI [(int)playerInventory.playerItems [i].type];
			}
			// set quantity

			// set name

			// remove excess grid icons
			if (isGridViewItems && i == rows - 1) {
				for (int k = playerInventory.playerItems.Count % 5; k != 0 && k < 5; k++) {
					Destroy (clone.GetChild (k).gameObject);
				}
			}
		}
	}

	void UpdateData() {
		// Clear data
		for (int i = 0; i < dataContainer.childCount; i++)
			Destroy (dataContainer.GetChild (i).gameObject);
		// Instantiate new UI elements
		int rows = isGridViewData ? playerInventory.playerData.Count / 5 + 1 : playerInventory.playerData.Count;
		if (isGridViewData && playerInventory.playerData.Count % 5 == 0)
			rows -= 1;
		dataContainer.sizeDelta = new Vector2(dataContainer.sizeDelta.x, rows * 19 + 3);
		RectTransform clone = null;
		for (int i = 0; i < rows; i++) {
			clone = Instantiate<RectTransform> (isGridViewData ? prefabGridView : prefabListView);
			clone.SetParent (dataContainer, false);
			clone.anchoredPosition = new Vector2 (clone.anchoredPosition.x, -(19 * i));
			// set icons
			if (isGridViewData) {
				for (int j = 0; j < 5 && (i * 5 + j) < playerInventory.playerData.Count; j++) {
					Image img = clone.GetChild (j).GetChild (0).GetComponent<Image> ();
					img.sprite = iconsUI [(int)playerInventory.playerData [i * 5 + j].type];
				}
			} else {
				Image img = clone.GetChild (0).GetComponent<Image> ();
				img.sprite = iconsUI [(int)playerInventory.playerData [i].type];
			}
			// set quantity

			// set name

			// remove excess grid icons
			if (isGridViewData && i == rows - 1) {
				for (int k = playerInventory.playerData.Count % 5; k != 0 && k < 5; k++) {
					Destroy (clone.GetChild (k).gameObject);
				}
			}
		}
	}

	// Events called by button clicks in UI
	public void OrganizerItemViewClick(bool isGridView) {
		isGridViewItems = isGridView;
		itemsOrganizerList.interactable = isGridViewItems;
		itemsOrganizerGrid.interactable = !isGridViewItems;
		if (isGridView)
			itemsOrganizerList.image.overrideSprite = itemsOrganizerList.image.sprite;
		else
			itemsOrganizerGrid.image.overrideSprite = itemsOrganizerGrid.image.sprite;
		UpdateItems ();
	}
	public void OrganizerDataViewClick(bool isGridView) {
		isGridViewData = isGridView;
		dataOrganizerList.interactable = isGridViewData;
		dataOrganizerGrid.interactable = !isGridViewData;
		if (isGridView)
			dataOrganizerList.image.overrideSprite = dataOrganizerList.image.sprite;
		else
			dataOrganizerGrid.image.overrideSprite = dataOrganizerGrid.image.sprite;
		UpdateData ();
	}
}
