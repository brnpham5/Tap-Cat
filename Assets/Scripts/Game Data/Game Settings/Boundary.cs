using UnityEngine;
using System.Collections;

public static class Boundary{
	private static float xMin, xMax;
	private static float yMin, yMax;
	private static Bounds bound;

/*
	public Boundary(float xMin, float xMax, float yMin, float yMax)
	{
		this.xMin = xMin;
		this.xMax = xMax;
		this.yMin = yMin;
		this.yMax = yMax;
	}
*/

	public static float Get_xMin(){
		return xMin;
	}
		
	public static float Get_xMax(){
		return xMax;
	}
		
	public static float Get_yMin(){
		return yMin;
	}
		
	public static float Get_yMax(){
		return yMax;
	}

	public static Bounds GetBound(){
		return bound;
	}
		
	public static void Set_xMin(float newValue){
		xMin = newValue;
	}

	public static void Set_xMax(float newValue){
		xMax = newValue;
	}

	public static void Set_yMin(float newValue){
		yMin = newValue;
	}

	public static void Set_yMax(float newValue){
		yMax = newValue;
	}

	public static void SetBound(Bounds newValue){
		bound = newValue;
	}


}