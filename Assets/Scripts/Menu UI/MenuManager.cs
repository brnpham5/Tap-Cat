using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuManager : MonoBehaviour {
//Definitions


	//Required Components
	public GameObject menu;
	public GameObject optionPanel;
	public GameObject catMenu;
	public GameObject catPanel;

	//Required Scripts
	public PauseManager pauseManager;

//Methods
	void Awake()
	{
		menu.SetActive (false);
		optionPanel.SetActive(false);
		catMenu.SetActive (false);
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ToggleOptionMenu ();
		}
	}


	public void ToggleMenu(){
		menu.SetActive(!menu.activeSelf);
	}


	public void ToggleOptionMenu(){
		optionPanel.SetActive(!optionPanel.activeSelf);
		pauseManager.Pause ();
	}


	public void ToggleCatMenu(){
		catMenu.SetActive (!catMenu.activeSelf);
		catPanel.SetActive (!catPanel.activeSelf);
	}

}
