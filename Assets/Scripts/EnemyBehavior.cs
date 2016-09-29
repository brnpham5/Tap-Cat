using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	//Movement System;
	public float moveSpeed;
	public float maxMoveDistance;
	private float currentSpeed;
	[Range(1,5)] 
	public float doSomethingDelay;
	private Vector2 moveDirection;

	//Health System;
	public int health;
	private int currentHealth;

	//Attack System;
	public int damage;
	private int targetIndex;
	private GameObject[] targetList;
	private Vector2 targetLocation;

	//Locks
	private bool busy;

	//Required Components
	public BoxCollider2D attackBox;
	public BoxCollider2D blockBox;
	public GameController gameController;
	private Rigidbody2D rb;
	private Animator anim;
	private SpriteRenderer sRend;
	private AnimatorStateInfo stateInfo;


	// Use this for initialization
	void Start () {
		//Initialize variables
		currentSpeed = moveSpeed;
		currentHealth = health;


		//Find reference to instance of GameController
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		//Debug - Reference - GameController
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}

		//Get Components
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sRend = GetComponent<SpriteRenderer> ();

		//Select a target;
		targetList = GameObject.FindGameObjectsWithTag("Cat");
		targetIndex = Random.Range (0, targetList.Length);

		//Start Personality System
		busy = false;
		StartCoroutine(DoSomething());
//		StartCoroutine (DamageCalculator ());

		//Add to list
		ListOfEnemies.Add (this.gameObject);


	}

	IEnumerator DoSomething(){
		while (currentHealth > 0) {
			
			if(busy == false){
				targetLocation = targetList[targetIndex].transform.position;
				moveDirection = Vector2.MoveTowards (rb.position, targetLocation, maxMoveDistance);
				yield return StartCoroutine(MoveToPosition (moveDirection));
				yield return new WaitUntil(() => rb.position == moveDirection);
			}
			yield return new WaitForSeconds (doSomethingDelay);

		}
	}

	//Move to position
	IEnumerator MoveToPosition(Vector2 newPosition){
		//Lock?
		busy = true;

		//Set moving animation
		anim.SetBool ("Moving", true);

		//Set direction of sprite towards moving direction
		if (rb.position.x <= newPosition.x) {
			sRend.flipX = false;
		} else if(rb.position.x >= newPosition.x){
			sRend.flipX = true;
		}

		//Physics update
		while (rb.position != newPosition) {
			rb.position = Vector2.MoveTowards(rb.position, newPosition, currentSpeed * Time.deltaTime);
			yield return new WaitForFixedUpdate ();
		}

		//Remove lock
		busy = false;

		//Set moving animation off
		anim.SetBool ("Moving", false);
	}



	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Cat")){
			anim.SetBool ("Attacking", true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Cat")){
			anim.SetBool ("Attacking", false);
		}
	}

	//On mouse down, deal damage
	void OnMouseDown(){
		if(!anim.GetBool("Is Dead")){
			anim.Play ("mon1_hurt");
		}
	}

	void TakingDamage(){
		currentHealth--;
		currentSpeed = 0.0f;
		if(currentHealth <= 0){
			anim.SetBool("Is Dead", true);
		}
	}

	void FinishedTakingDamage(){
		currentSpeed = moveSpeed;

	}


	void Death(){
		gameObject.SetActive(false);
		currentHealth = health;
	}
}
