using UnityEngine;
using System.Collections;

public class AffectionController : MonoBehaviour {
//Definitions
	//Affection Points
	public int affection = 0;							//Total Amount of affection


	//Required Scripts
	public AffectionUI affectionUI;

//Methods
	void Awake(){
		//Initialize affection value
		affectionUI.UpdateAffection (affection);		
	}


	//Add points to affection amount
	public void AddAffection(int newAffectionValue){
		affection += newAffectionValue;
		affectionUI.UpdateAffection (affection);
	}


}
