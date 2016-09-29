using UnityEngine;
using System.Collections;

public class BlueCatAffection : MonoBehaviour, ICatAffection {
//Definitions
	//Affection System
	public int affectionValue = 1;				//how much affection per click
	public int affectionLevel = 1;				//affection level of cat (level up in individual cat personality scripts)
	public int currentAffection = 0;			//amount of affection given out so far
	public int maxAffection = 10;				//max affection allowed to give out through clicking

	//Required Components

	//Required Scripts
	private AffectionController affectionController;


	//Methods
	void Awake(){
		//Find reference to instance of AffectionController
		FindAffectionController();

		//Get Components
	
	}

	public void FindAffectionController(){
		//Find reference to instance of AffectionController
		GameObject affectionControllerObject = GameObject.FindWithTag ("AffectionController");
		if (affectionControllerObject != null) {
			affectionController = affectionControllerObject.GetComponent<AffectionController> ();
		}

		//Debug - Reference - GameController
		if (affectionController == null) {
			Debug.Log("Cannot find 'AffectionContoller' script");
		}
	}

	public void AddAffection(){

	}

	//On mouse down, add affection
	void OnMouseDown(){
		affectionController.AddAffection (affectionValue);
	}

}


/*
Affection System:
	OnClick - add affection up to a max
		-Eventually reset ability to click on cat for affection
		-Display hearts over head

	Automatic - periodically add affection
		-Probably in coroutine that adds affection over time

	Affection Level- when achieving a certain amount of affection level up cat
		-Increase level
		-Increase affection per click
		-Increase automatic affection
		-Increase health?

	-Reset Affection - when cat hits affection max reset current affection after a countdown
		-OR lower affection level over time. Probably both
*/