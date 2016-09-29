using UnityEngine;
using System.Collections.Generic;

public static class ListOfEnemies {
	public static List<GameObject> list = new List<GameObject>();

	public static void Add(GameObject newObject){
		list.Add (newObject);
	}

	public static void Remove(GameObject target){
		for(int i = 0; i < list.Count; i++){
			if(GameObject.ReferenceEquals(target, list[i])){
				list.RemoveAt (i);
				break;
			}
		}
	}

	public static List<GameObject> GetList(){
		return list;
	}

	public static GameObject GetObject(int index){
		return list [index];
	}

	public static int Count(){
		return list.Count;
	}

	public static bool Contains(string name, out GameObject target){
		foreach (GameObject targetObject in list) {
			if (targetObject.tag.Equals (name)) {
				target = targetObject;
				return true;
			} 
		}

		target = null;
		return false;

	}

}
