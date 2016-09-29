using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatePatternCat : MonoBehaviour {
//Definitions
	public string catType;

	//Required Components
	private Animator anim;

	//Required Scripts

	//Cat State Machine
	[HideInInspector] public ICatStates currentState;
	[HideInInspector] public CatNormalState normalState;
	[HideInInspector] public CatScaredState scaredState;
	[HideInInspector] public CatAffectionateState affectionateState;

	//Cat Personality
	public ICatPersonality catPersonality;						//Interface reference for cat personality to subscribe itself to



	//Required Scripts
	private CatMovement catMovement;

	//Play with ball variables
	private YarnBall smackTarget;
	private bool smackBool;

//Methods

	private void Awake()
	{
		//Initialize States
		normalState = new CatNormalState (this);
		scaredState = new CatScaredState (this);
		affectionateState = new CatAffectionateState (this);

		//Get Required Components
		anim = GetComponentInChildren<Animator> ();

		//Get Required Scripts
		catMovement = GetComponent<CatMovement> ();
		ListOfCats.Add (this.gameObject);

		catPersonality.SendData ();
	}


	// Use this for initialization
	void Start () 
	{
		currentState = normalState;
		StartCoroutine (DoSomething ());
		normalState.PrintActionData ();
	}

	public IEnumerator DoSomething(){
		string action;
		while (true) {
			action = currentState.GetAction();
			switch (action) {
			case "Move":
				yield return StartCoroutine (Move ());
				break;
			case "Idle":
				yield return StartCoroutine (Idle ());
				break;
			case "Anim":
				yield return StartCoroutine (Anim ());
				break;
			case "Follow":
				yield return StartCoroutine (Follow ());
				break;
			case "Ball":
				yield return StartCoroutine (PlayBall ());
				break;
			default:
				break;
			}
		}
	}

//Normal State Actions
	//Move cat to random position
	public IEnumerator Move(){
		yield return StartCoroutine(catMovement.MoveRandomRoutine());
	}


	//Idle for a random amount of time
	public IEnumerator Idle(){
		float timer;
		timer = Random.Range(2.0f, 5.0f);
		timer = Time.time + timer;

		while (Time.time < timer) {
			yield return null;
		}

	}

	//Play Idle Animation
	public IEnumerator Anim(){
		float timer;
		timer = Random.Range (1.0f, 3.0f);

		//Set playing animation
		anim.SetBool ("Playing", true);

		//Set timer
		timer = Time.time + timer;

		//Wait for a random amount of time between range
		while (Time.time < timer) {
			yield return null;
		}

		//Set playing animation off
		anim.SetBool ("Playing", false);
		yield return StartCoroutine (Idle());

	}


	//Follow mouse pointer
	public IEnumerator Follow(){
		float timer;
		timer = Random.Range (3.0f, 8.0f);
		yield return StartCoroutine(catMovement.FollowRoutine(timer, "Mouse"));

	}


	public IEnumerator PlayBall(){
		float timer = Random.Range (3.0f, 8.0f);
		smackBool = true;
		yield return StartCoroutine (catMovement.FollowRoutine (timer, "Ball"));
		smackBool = false;
	}


	//On trigger enter
	void OnTriggerEnter2D(Collider2D other){

		//if collision with "Ball"
		if (other.CompareTag("Ball") && smackBool == true) {
			//smack it
			Vector2 relativePosition;
			smackTarget = other.GetComponent<YarnBall> ();
			Debug.Log ("SMACK");
			relativePosition = other.transform.position - this.transform.position;
			smackTarget.GetSmacked (relativePosition);
		}

	}

//Affectionate State Actions


//Scared State Actions


}
