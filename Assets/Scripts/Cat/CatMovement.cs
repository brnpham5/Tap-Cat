using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {
//Definitions
	public float moveSpeed = 1.0f;
	private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();


	//Delegate to get target position
	private delegate Vector2 FollowTarget ();
	private FollowTarget followTarget;

	//Reference to target gameobject to move towards
	GameObject targetObject;

	//Required Components
	private Animator anim;
	private SpriteRenderer sRend;
	private Rigidbody2D rb;

//Methods
	void Awake(){
		//Get Components
		anim = GetComponentInChildren<Animator> ();
		sRend = GetComponentInChildren<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();


	}
		
	//Move to position
	public IEnumerator MoveRoutine(Vector2 newPosition, float timer){
		Vector2 prevLocation;

		//Set moving animation
		anim.SetBool ("Moving", true);

		//Set direction of sprite towards moving direction
		facePosition(newPosition.x);

		//Set timer
		timer = Time.time + timer;

		//Set previous location
		prevLocation = rb.position;

		//Physics update
		while (rb.position != newPosition && Time.time < timer) {
			rb.position = Vector2.MoveTowards(rb.position, newPosition, moveSpeed * Time.deltaTime);
			if (prevLocation != rb.position) {
				prevLocation = rb.position;
			} else if (prevLocation == rb.position) {
				timer = Time.time;
			}
			yield return fixedUpdate;
		}

		//Set moving animation off
		anim.SetBool ("Moving", false);
	}

	//Move to a random position
	public IEnumerator MoveRandomRoutine(){
		Vector2 prevPosition;
		Vector2 newPosition;
		float timer = 5.0f;

		//Get Random position within boundary
		newPosition = new Vector2 (Random.Range (Boundary.Get_xMin(), Boundary.Get_xMax()), Random.Range (Boundary.Get_yMin(), Boundary.Get_yMax()));

		//Set moving animation
		anim.SetBool ("Moving", true);

		//Set direction of sprite towards moving direction
		facePosition(newPosition.x);

		//Set timer
		timer = Time.time + timer;

		//Set previous location
		prevPosition = rb.position;

		//Physics update
		while (rb.position != newPosition && Time.time < timer) {
			rb.position = Vector2.MoveTowards(rb.position, newPosition, moveSpeed * Time.deltaTime);
			if (prevPosition != rb.position) {
				prevPosition = rb.position;
			} else if (prevPosition == rb.position) {
				timer = Time.time;
			}
			yield return fixedUpdate;
		}

		//Set moving animation off
		anim.SetBool ("Moving", false);
	}

	public IEnumerator FollowRoutine(float timer, string target){
		//Local Definitions
		Vector2 targetPosition;

		//Set target
		switch (target) {
		case "Mouse":
			//Set followTarget delegate to get mouse position method
			followTarget = GetMousePointerPosition;
			break;
		case "Ball":
			//Search for a ball, and get reference to it
			if (ListOfToys.Contains("Ball", out targetObject) == true) {
				followTarget = GetBallPosition;
			} else {
				//If there's no ball, break out of coroutine
				yield break;
			}
			break;
		default:
			break;
		}

		//Set moving animations
		anim.SetBool("Moving", true);

		//Set timer
		timer = Time.time + timer;



		//Physics Update + Mouse Follow for timer seconds
		while (Time.time < timer) {
			//Get target position
			targetPosition = followTarget();

			//Face direction of sprite to moving position
			facePosition (targetPosition.x);

			//Set animation to moving if cat is not at position
			if (rb.position != targetPosition) {
				anim.SetBool ("Moving", true);

				//else set animation to not moving when it is
			} else if (rb.position == targetPosition) {
				anim.SetBool ("Moving", false);
			}

			//Physics update
			rb.position = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
			yield return fixedUpdate;
		}
			
		//Set moving animation off
		anim.SetBool("Moving", false);

	}

	//Get mouse pointer position
	Vector2 GetMousePointerPosition(){
		return Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	//Get ball position
	Vector2 GetBallPosition(){
		if (targetObject != null) {
			//return position of ball
			return targetObject.transform.position;
		} else {
			//return position of this cat
			return Vector2.zero;

		}
	}

/*
	void Update(){
		//Check for mouse click on play area and then set move
		if (Input.GetMouseButtonDown (0) && isMoving == false && moveClick == true) {
			SendMessage ("DeactivatePersonality");
			clickPosition.Set (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
			newPosition = Camera.main.ScreenToWorldPoint (clickPosition);
			Debug.Log (newPosition.x + " " + newPosition.y);
			Move (newPosition, 5.0f);

		}

	}
*/	

	//Face direction of movement
	private void facePosition(float xValue){
		if (rb.position.x <= xValue) {
			sRend.flipX = false;
		} else if(rb.position.x >= xValue){
			sRend.flipX = true;
		}
	}

	//Set Sorting order for object
	public void SetSortingOrder(){
		sRend.sortingOrder = (int) -(rb.position.y * 25);
	}

	//Set sprite renderer sorting order to y position
	private void FixedUpdate(){
		SetSortingOrder ();
	}


}
