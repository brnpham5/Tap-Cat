using UnityEngine;
using System.Collections;

public interface ICatStates{
	string GetAction();

	void AddAction (string newAction, int newWeight);

	void RemoveAction (string targetAction);

	void ToNormalState();

	void ToAffectionateState();

	void ToScaredState();

}
