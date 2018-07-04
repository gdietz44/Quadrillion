using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TouchScript.Gestures.TransformGestures;

public class StartGame : MonoBehaviour {
	float startAngle = 0;
	float rotated = 0;

	// Use this for initialization
	void Start () {
		GameObject red = addSprite("Red", "puzzle_pieces/red");
		GameObject orange = addSprite("Orange", "puzzle_pieces/orange");
		GameObject yellow = addSprite("Yellow", "puzzle_pieces/yellow");
		GameObject green = addSprite("Green", "puzzle_pieces/green");
		GameObject blue = addSprite("Blue", "puzzle_pieces/blue");
		GameObject purple = addSprite("Purple", "puzzle_pieces/purple");
		GameObject pink = addSprite("Pink", "puzzle_pieces/pink");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	GameObject addSprite(string objName, string resourcePath) {
		GameObject go = new GameObject(objName);
		go.layer = 9;
		SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
		Sprite tangram = Resources.Load<Sprite>(resourcePath);
		renderer.sprite = tangram;
		renderer.sortingLayerName = "Tangram";
		// renderer.transform.localScale = new Vector3((float)0.35, (float)0.35, (float)0.35);
		TransformGesture tg = go.AddComponent<TransformGesture>();
		tg.Transformed += pointUpdate;
		tg.TransformCompleted += transformEnd;
		tg.Type = TransformGesture.TransformType.Translation | TransformGesture.TransformType.Rotation;
		go.AddComponent<TouchScript.Behaviors.Transformer>();
		Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
		go.AddComponent<PolygonCollider2D>();
		return go;
	}

	private void pointUpdate(object sender, System.EventArgs e) {
		TransformGesture tg = sender as TransformGesture;
		GameObject go = tg.gameObject;
		go.GetComponent<SpriteRenderer>().sortingLayerName = "Active_Tangram";
		Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
		rb.constraints = 0;
		rb.mass = 1;
	    if(go.layer == 9 && tg.NumPointers > 1) {
	    	go.layer = 10;
	    } else if (go.layer == 10 && tg.NumPointers == 1) {
	    	go.layer = 9;
	    }
	}

	private void transformEnd(object sender, System.EventArgs e) {
		TransformGesture tg = sender as TransformGesture;
		GameObject go = tg.gameObject;
    	go.layer = 9;
    	go.GetComponent<SpriteRenderer>().sortingLayerName = "Tangram";
    	Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
    	rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    	rb.mass = 100;
    	setAngle(go);
    	setPosition(go);

	}

	private void setAngle(GameObject go) {
		float angle = go.transform.rotation.eulerAngles.z;
    	if (angle > 315 || angle <= 45) {
    		go.transform.eulerAngles = new Vector3(0, 0, 0);
		} else if (angle > 45 && angle <= 135) {
			go.transform.eulerAngles = new Vector3(0, 0, 90);
		} else if (angle > 135 && angle <= 225) {
			go.transform.eulerAngles = new Vector3(0, 0, 180);
		} else if (angle > 225 && angle <= 315) {
			go.transform.eulerAngles = new Vector3(0, 0, 270);
		}
	}

	private void setPosition(GameObject go) {
		go.transform.position = new Vector3(Mathf.RoundToInt(go.transform.position.x), Mathf.RoundToInt(go.transform.position.y), go.transform.position.z);
	}

}
