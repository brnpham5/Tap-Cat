using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour {

//Definitions
	//Health System
	public int startingHealth = 10;				// Starting health.
	public int currentHealth;					// Current health.
	public Slider healthSlider;					// Slider UI for health

	//Required Components
	Animator anim;								// Reference to the animator.

	//Required Scripts

	//Bools for checking
	private bool isDead;						// Whether the cat is dead.


//Methods
	void Awake(){
		//Get Components
		anim = GetComponent <Animator> ();
	}
		
	void Start(){
		//Initialize variables
		currentHealth = startingHealth;
	}
		
	public void TakeDamage (int amount)
	{
		if(isDead)
			return;

		currentHealth -= amount;

		if(currentHealth <= 0)
		{
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;

		anim.SetTrigger ("Death");
	}

}
