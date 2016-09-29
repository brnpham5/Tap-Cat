using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatNormalState : ICatStates {
	private int actionsCount = 0;
	private List<string> actions = new List<string>();
	private List<int> weights = new List<int> ();

	//Required Components


	//Required Scripts
	private readonly StatePatternCat cat;


//Methods - ICatStates
	public CatNormalState(StatePatternCat statePatternCat){
		cat = statePatternCat;
	}

	public string GetAction(){
		return actions [Choose (weights)];
	}

	public void AddAction(string newAction, int newWeight){
		if (!actions.Contains (newAction)) {
			actionsCount++;
			actions.Add (newAction);
			weights.Add (newWeight);
		}
	}

	public void RemoveAction(string targetAction){
		if(actions.Contains(targetAction)){
			int index = actions.IndexOf(targetAction);
			actionsCount--;
			actions.RemoveAt(index);
			weights.RemoveAt(index);
		}

	}

	public void ToNormalState(){
		Debug.Log ("Cannot transition to same state");
	}


	public void ToAffectionateState(){
		cat.currentState = cat.affectionateState;
	}


	public void ToScaredState(){
		cat.currentState = cat.scaredState;
	}

	public void PrintActionData(){
		for (int i = 0; i < actions.Count; i++) {
			Debug.Log (actions [i] + " " + weights [i]);
		}
	}

	//Choose a random weight to determine which index to return
	private int Choose (List<int> probs) {
		float total = 0;

		for (int i = 0; i < actionsCount; i++) {
			total += probs[i];

		}
		float randomPoint = Random.value * total;
		for (int i= 0; i < actionsCount; i++) {
			if (randomPoint < probs[i]) {
				return i;
			}
			else {
				randomPoint -= probs[i];
			}
		}
		return probs.Count - 1;
	}
				
}
