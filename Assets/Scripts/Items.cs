using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

	public enum itemIDs {Antidote, Bandage, Book_blue, Book_brown, Book_green, Book_red, Booster_shot, Coins,
		Detoxin, Duct_tape, Energy_cell, Envelope_closed, Envelope_open, Envelope_sealed, Envelope_unsealed, Medkit};

	public Sprite[] UI_itemSprites = new Sprite[16];

	public static int getID(string tag) {
		switch (tag) {
		case "Antidote": 
			return (int) itemIDs.Antidote;
			
		case "Bandage": 
			return (int) itemIDs.Bandage;
			 
		case "Book_blue": 
			return (int) itemIDs.Book_blue;
			 
		case "Book_brown": 
			return (int) itemIDs.Book_brown;
			 
		case "Book_green": 
			return (int) itemIDs.Book_green;
			 
		case "Book_red": 
			return (int) itemIDs.Book_red;
			 
		case "Booster_shot": 
			return (int) itemIDs.Booster_shot;
			 
		case "Coins": 
			return (int) itemIDs.Coins;
			
		case "Detoxin": 
			return (int) itemIDs.Detoxin;
			 
		case "Duct_tape": 
			return (int) itemIDs.Duct_tape;
			 
		case "Energy_cell": 
			return (int) itemIDs.Energy_cell;
			 
		case "Envelope_closed": 
			return (int) itemIDs.Envelope_closed;
			 
		case "Envelope_open": 
			return (int) itemIDs.Envelope_open;
			 
		case "Envelope_sealed": 
			return (int) itemIDs.Envelope_sealed;
			 
		case "Envelope_unsealed": 
			return (int) itemIDs.Envelope_unsealed;
			 
		case "Medkit": 
			return (int) itemIDs.Medkit;
			
		default: 
			return (int) -1;
			
		}
	}
}
