using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public ItemSprites[] itemSprites;

	[System.Serializable]
	public struct ItemSprites {
		public Sprite[] sprites;
	}

	// Keep GameController object prevalent through all scenes
	static GameController _instance;
	void Awake ()
	{
		DontDestroyOnLoad (this);
	}

	// Check for debugging input
	void Update ()
	{
		if (TeamUtility.IO.InputManager.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (TeamUtility.IO.InputManager.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	}

	//	public Item GenerateNewItem(string name = "Bandage", int quantity = 1, int spriteID = 0, int uiID = 1) {
	//		return new Item(name, quantity, itemSprites[spriteID], iconsUI[uiID]);
	//	}

}