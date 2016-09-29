using UnityEngine;
using System.Collections;

public class YarnBall : MonoBehaviour, ISortingOrderable {
//Definitions
	private Vector2 moveDirection;
	private float yVelocity;

	//Required Components
	private Rigidbody2D rb;
	private SpriteRenderer sRend;

	//Required Scripts
	private GameController gameController;


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

		//Get Componets
		rb = GetComponent<Rigidbody2D> ();
		sRend = GetComponentInChildren<SpriteRenderer> ();

	}

	void Start(){
		ListOfToys.Add(this.gameObject);
	}

	void OnEnable(){
		
	}


	void OnDisable(){
		
	}


	public void GetSmacked(Vector2 catSmack){
		rb.velocity = catSmack * 5;
	}


	public void SetSortingOrder(){
		sRend.sortingOrder = (int) -(rb.position.y * 25);
	}


	void FixedUpdate(){
		SetSortingOrder ();
		moveDirection = rb.velocity;

		if (moveDirection != Vector2.zero) {
			if (moveDirection.x >= 0) {
				yVelocity = Mathf.Abs (moveDirection.y);
			} else if (moveDirection.x < 0) {
				yVelocity = -Mathf.Abs (moveDirection.y);
			}
		transform.Rotate (0.0f, 0.0f, -(moveDirection.x + yVelocity) * 10);

		}
	}
}


/*
		float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg * 2;
		angle += Mathf.Atan (moveDirection.x) * Mathf.Rad2Deg / 5;
		
  		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
  		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime);
  		Quaternion.Euler(0.0f, 0.0f, angle);


		angle += rb.velocity.magnitude * 10;
		Debug.Log (rb.velocity.magnitude + " " + rb.velocity.sqrMagnitude);
		angle = angle % 360;
//		Debug.Log (angle);
		transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
*/