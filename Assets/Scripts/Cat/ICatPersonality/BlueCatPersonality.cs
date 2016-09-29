using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BlueCatPersonality: MonoBehaviour, ICatPersonality{
	//Definitions


	//Required Scripts
	private StatePatternCat cat;							//Reference to StatePatternCat

	//Methods
	void Awake(){
		//Get Scripts
		cat = GetComponent<StatePatternCat>();

		//Subscribe itself to StatePatternCat, catPersonality interface reference
		cat.catPersonality = this;

		//Get Traits
		cat.catType = "BlueCat";

	}

	public void SendData(){
		for(int i = 0; i < BlueCatDataStatic.normalActions.Count; i++){
			cat.normalState.AddAction(BlueCatDataStatic.normalActions[i], BlueCatDataStatic.normalWeights[i]);
		}

		for (int i = 0; i < BlueCatDataStatic.affectionateActions.Count; i++) {
			cat.affectionateState.AddAction (BlueCatDataStatic.affectionateActions [i], BlueCatDataStatic.affectionateWeights [i]);
		}

		for (int i = 0; i < BlueCatDataStatic.scaredActions.Count; i++) {
			cat.affectionateState.AddAction (BlueCatDataStatic.affectionateActions [i], BlueCatDataStatic.affectionateWeights [i]);
		}
	}

}





/*
	private void GetTraits(){
		//Set traits count to 0
		traitsCount = 0;

		//Get traits and assign weights
		for (int i = 0; i < CatTraits.traitsCount; i++) {
			switch (CatTraits.traits[i]) {
			case "Move":
				AddTrait (i);
				traitsCount++;
				break;
			case "Idle":
				AddTrait (i);
				traitsCount++;
				break;
			case "Anim":
				AddTrait (i);
				traitsCount++;
				break;
			case "Follow":
				AddTrait (i);
				traitsCount++;
				break;
			default:
				break;
			}
		}
		Debug.Log("Weights: " + weights[0] + " " + weights[1] + " " + weights[2] + " " + weights[3]);

	}


	private void AddTrait(int index){
		traits.Add (CatTraits.traits [index]);
		AddWeight (CatTraits.traits [index]);
	}


	private void AddWeight(string trait){
		weights.Add(weightsBound.GetWeight(trait));
	}

	public void AddTrait(string trait){
		//if trait is already in list, return
		if (!traits.Contains (trait)) {
			for (int i = 0; i < CatTraits.traitsCount; i++) {
				if (CatTraits.traits [i].Equals (trait)) {
					traits.Add (CatTraits.traits [i]);
					traitsCount++;
				}
			}
		}
	}

	public void RemoveTrait(string trait){
		if (traits.Contains (trait)) {
			traits.Remove (trait);
			traitsCount++;
		}
	}

	public string GetAction(){
		return traits [Choose (weights)];
	}


	//Choose a random weight to determine which index to return
	private int Choose (List<int> probs) {

		float total = 0;

		for (int i = 0; i < traitsCount; i++) {
			total += weights[i];
		}
		float randomPoint = Random.value * total;
		for (int i= 0; i < probs.Count; i++) {
			if (randomPoint < probs[i]) {
				return i;
			}
			else {
				randomPoint -= probs[i];
			}
		}
		return probs.Count - 1;
	}

	//Activates the personality coroutine
public void ActivatePersonality(){
	active = true;
	StartCoroutine (Personality ());

}

//Sets active to false to stop the coroutine
public void DeactivatePersonality(){
	active = false;
}

//Personality coroutine to continually have the cat do things
private IEnumerator Personality(){
	string action;
	while (active) {
		action = traits [Choose (weights)];
		yield return catController.StartCoroutine(action);
	}

	yield return null;
}
*/