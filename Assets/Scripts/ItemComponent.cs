using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class ItemComponent : MonoBehaviour {

	public Item item;

	void OnValidate() {
		GameController gc = GameObject.FindObjectOfType<GameController>();
		SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer> ();
		Sprite[] sprs = gc.itemSprites [(int)item.type].sprites;
		item.spriteVariantMax = sprs.Length;
		if (sprs.Length > 0) {
			item.spriteVariant = Mathf.Clamp (item.spriteVariant, 1, item.spriteVariantMax);
			spr.sprite = sprs [item.spriteVariant - 1];
		}
	}

	void Awake() {
		BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D> ();
		bc.isTrigger = true;
	}

	public Item Copy() {
		Item i = new Item ();
		i.itemName = item.itemName;
		i.quantity = item.quantity;
		i.isData = item.isData;
		i.type = item.type;
		i.spriteVariant = item.spriteVariant;
		i.spriteVariantMax = item.spriteVariantMax;
		return i;
	}
}
