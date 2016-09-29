using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour, IDraggable {
//Definition
	//On Mouse Down Variables
//	Vector3 screenSpace;						//Not required in 2D
	Vector2 resetVelocity;
	Vector3 offset;
	Vector3 clickPosition;

	//On Drag variables
	Vector3 curScreenSpace;
	Vector3 curPosition;


	//Required Components
	Rigidbody2D rb;

//Methods
	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		resetVelocity = new Vector2 (0.0f, 0.0f);
	}

	public void OnMouseDown(){
		//translate the object's position from world to screen point (not neccessary in 2D)
//		screenSpace = Camera.main.WorldToScreenPoint(transform.position);

		//calculate difference between object's position and the mouse screen position converted to a world point
		clickPosition.Set(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		offset = transform.position - Camera.main.ScreenToWorldPoint(clickPosition);


	}

	public void OnMouseDrag(){
		//keep track of mouse position
		curScreenSpace.Set(Input.mousePosition.x, Input.mousePosition.y, 0.0f);

		//convert the screen mouse position to world point and adjust with offset
		curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

		//update the position of the object in the world
		transform.position = curPosition;

	}

	public void OnMouseUp(){
		//Set velocity to 0
		rb.velocity = resetVelocity;
	}

}
