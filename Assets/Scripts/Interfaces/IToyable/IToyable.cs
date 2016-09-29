using UnityEngine;
using System.Collections;

public interface IToyable {
	void Count();					//Get count of toy to limit number

	void GetPrice ();				//Get price of toy

	void GetDurability();			//Get durability of toy?

	void SetDurability();			//Set durability of toy?

	void Play();					//Play action of toy
}



/*
Toy Properties:
	Price
	Durability
	Affection Boost?
	Play Action
		-Give Affection
*/