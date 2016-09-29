using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class CatData {
	public List<string> normalActions = new List<string> ();
	public List<int> normalWeights = new List<int>();

	public List<string> affectionateActions = new List<string> ();
	public List<int> affectionateWeights = new List<int>();

	public List<string> scaredActions = new List<string> ();
	public List<int> scaredWeights = new List<int>();

	public void AddAction(string type, string newAction, int newWeight){
		switch(type){
		case "Normal":
			if (!normalActions.Contains (newAction)) {
				normalActions.Add (newAction);
				normalWeights.Add (newWeight);
			}
			break;

		case "Affectionate":
			if (!affectionateActions.Contains (newAction)) {
				affectionateActions.Add (newAction);
				affectionateWeights.Add (newWeight);
			}
			break;
		
		case "Scared":
			if (!scaredActions.Contains (newAction)) {
				scaredActions.Add (newAction);
				scaredWeights.Add (newWeight);
			}
			break;

		default:
			break;
		}
	}

	public void RemoveAction(string type, string targetAction){
		switch(type){
		case "Normal":
			if(normalActions.Contains(targetAction)){
				int index = normalActions.IndexOf(targetAction);
				normalActions.RemoveAt(index);
				normalWeights.RemoveAt(index);
			}
			break;

		case "Affectionate":
			if(affectionateActions.Contains(targetAction)){
				int index = affectionateActions.IndexOf(targetAction);
				affectionateActions.RemoveAt(index);
				affectionateWeights.RemoveAt(index);
			}
			break;

		case "Scared":
			if(scaredActions.Contains(targetAction)){
				int index = scaredActions.IndexOf(targetAction);
				scaredActions.RemoveAt(index);
				scaredWeights.RemoveAt(index);
			}
			break;

		default:
			break;

		}
	}
}
