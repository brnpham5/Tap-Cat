using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlueCatData : CatData {


	public BlueCatData(){
		//Type, Action, Weight
		AddAction ("Normal", "Move", 30);
		AddAction ("Normal", "Idle", 40);
		AddAction ("Normal", "Anim", 30);
		AddAction ("Normal", "Follow", 5);
	}

}
