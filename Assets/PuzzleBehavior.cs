using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class TangramBehavior : MonoBehaviour {
	EdgeCollider2D ec;
	TapGesture tap;


	// Use this for initialization
	void Start () {
		//add colliders
		ec = gameObject.AddComponent(typeof(EdgeCollider2D)) as EdgeCollider2D;
		//add gestures
		tap = gameObject.AddComponent(typeof(TapGesture)) as TapGesture;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
