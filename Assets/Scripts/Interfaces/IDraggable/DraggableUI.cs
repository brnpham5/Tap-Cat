using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	//Definitions
	private Vector2 offset;									//Offset between pointer position and object position
	private Vector2 eventPosition;							//Position of click
	private Vector3 trans;									//Transform of object


	//Required Components

	//Methods
	void Awake(){
		//Get Components

	}


	public void OnBeginDrag(PointerEventData eventData){
		Debug.Log ("OnBeginDrag");

		//Find offset of click position and object anchor
		eventPosition = eventData.position;
		trans = this.transform.position;
		offset.Set (eventPosition.x - trans.x, eventPosition.y - trans.y);
	}


	public void OnDrag(PointerEventData eventData){
		//Move position of the object to where user drags to
		this.transform.position = eventData.position - offset;

	}


	public void OnEndDrag(PointerEventData eventData){
		Debug.Log ("OnEndDrag");

	}


}
