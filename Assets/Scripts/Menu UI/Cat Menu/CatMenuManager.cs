using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CatMenuManager : MonoBehaviour {
//Definitions
	private int catCount;
	private Vector2 scrollPanelSize;

//Required Components
	public GameObject blueCatButton;
	public GameObject catMenuScrollPanel;
	private RectTransform rectTransform;

//Required Scripts
	private GameController gameController;
	private StatePatternCat statePatternCat;

//Methods
	void Awake(){
		//Find reference to instance of GameController
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		//Debug - Reference - GameController
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' script");
		}

		//Get Reference to self
		catMenuScrollPanel = this.gameObject;

		//Get Components
		rectTransform = GetComponent<RectTransform> ();

	}


	void Start(){
		catCount = ListOfCats.list.Count;
		scrollPanelSize = new Vector2 (78 * catCount, 75);
		rectTransform.sizeDelta = scrollPanelSize;
		InitializeList ();
	}

		
	//Initialize Initial List of Cats for Cat Menu
	private void InitializeList(){
		for (int i = 0; i < catCount; i++) {
			AddCat (ListOfCats.list [i]);
		}
	}


	public void AddCat(GameObject cat){
		statePatternCat = cat.GetComponent<StatePatternCat> ();
		switch (statePatternCat.catType) {
		case "BlueCat": 
			Debug.Log ("Blue Cat in List");
			GameObject catButton = Instantiate (blueCatButton);
			catButton.transform.SetParent (catMenuScrollPanel.transform, false);
			BlueCatMenuItem menuItem = catButton.GetComponent<BlueCatMenuItem> ();
			menuItem.GetCat (cat);
			break;

		default:
			Debug.Log ("Not a cat");
			return;
		}
	}
		
	//Remove from list
	public void RemoveFromList(){

	}


}
