using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlueCatMenuItem : MonoBehaviour, ICatMenuItem{
//Definitions

	//Required Components
	private Slider healthSlider;
	private Text affectionLevelText;

	public GameObject thisCat;
	private SpriteRenderer sRend;
	private Button myBtn;

	//Required Scripts
	private BlueCatAffection catAffection;
	private CatHealth catHealth;

//Methods
	void Awake(){
		myBtn = GetComponent<Button> ();
		healthSlider = GameObject.Find("Cat Health Slider").GetComponent<Slider>();
		affectionLevelText = GameObject.Find("Cat Affection Level").GetComponent<Text>();
	}


	void Start(){
		catAffection = thisCat.GetComponent<BlueCatAffection> ();
		catHealth = thisCat.GetComponent<CatHealth> ();

	}


	void Update(){
		sRend = thisCat.GetComponentInChildren<SpriteRenderer> ();
		myBtn.image.sprite = sRend.sprite;
	}


	public void GetCat(GameObject cat){
		thisCat = cat;
	}

	public void SendCatData(){
		healthSlider.maxValue = catHealth.startingHealth;
		healthSlider.minValue = 1;
		healthSlider.value = catHealth.currentHealth;
		affectionLevelText.text = "Affection Level: " + catAffection.affectionLevel;
	}

}


/*
Cat Menu Item
	Button
		On push, display a panel with the cat's information:	
			Health
			Affection level
			Personality Values - PV
	Sprite of Cat
	
*/