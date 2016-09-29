using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AffectionUI : MonoBehaviour {
//Definitions
	//Variables

	//Required Components
	public Text affectionText;

//Methods
	void Awake(){
		affectionText = GetComponent<Text> ();
	}



	//Update the affection UI
	public void UpdateAffection(int affection){
		affectionText.text = "Affection: " + affection;
	}
}
