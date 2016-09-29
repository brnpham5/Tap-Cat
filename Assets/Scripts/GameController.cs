using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {
//Definitions
	private Vector2 randomPosition;

	//Required Components
	private Camera mainCamera;

	//Required Scripts
	CatData catData;

	//List of game objects;
	public List<GameObject> catsList = ListOfCats.GetList();
	public List<GameObject> enemiesList = ListOfEnemies.GetList();
	public List<GameObject> toysList = ListOfToys.GetList();


//Methods
	void Awake(){
		//Find reference to main camera
		GameObject mainCameraObject = GameObject.FindWithTag ("MainCamera");
		if (mainCameraObject != null) {
			mainCamera = mainCameraObject.GetComponent<Camera> ();
		}

		//Debug - Reference - main camera
		if (mainCameraObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}

		SetBoundary ();
	}


	public void SetBoundary(){
		Bounds bound = CameraExtensions.OrthographicBounds (mainCamera);
		Boundary.SetBound (bound);
		Boundary.Set_xMin (bound.min.x);
		Boundary.Set_xMax (bound.max.x);
		Boundary.Set_yMin (bound.min.y);
		Boundary.Set_yMax (bound.max.y);
		Debug.Log ("Boundary: " + bound.min.x + " " + bound.max.x + " " + bound.min.y + " " + bound.max.y); 
	}

	//Add new cat to cat list
//	public void AddNewCat(GameObject newCat){
//		catsList.Add (newCat);
//	}

	//Add new enemy to enemy list
//	public void AddNewEnemy(GameObject newEnemy){
//		enemiesList.Add (newEnemy);
//	}

//	public void AddNewToy(GameObject newToy){
//		toysList.Add (newToy);
//	}

	//Return a random position within set bounds
	public Vector2 RandomPosition(){
		randomPosition.Set(Random.Range (Boundary.Get_xMin(), Boundary.Get_xMax()), Random.Range (Boundary.Get_yMin(), Boundary.Get_yMax()));
		return randomPosition;
	}               



}


/*
	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("Name = " + hit.collider.name);
				Debug.Log ("Tag = " + hit.collider.tag);
				Debug.Log ("Hit Point = " + hit.point);
				Debug.Log ("Object position = " + hit.collider.gameObject.transform.position);
				Debug.Log ("------------");
			}
		}
	}

*/