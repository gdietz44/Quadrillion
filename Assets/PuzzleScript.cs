using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TouchScript.Gestures;

public class PuzzleScript : MonoBehaviour {
	private SpriteRenderer puzzleSpriteRenderer;
	private int puzzleNumber = 1;

	void Start () {
		createPuzzle();
		// createNextPuzzleButton();
	}

	void createPuzzle() {
		GameObject go = new GameObject("Puzzle");
		go.layer = 8;
		puzzleSpriteRenderer = go.AddComponent<SpriteRenderer>();
		Sprite puzzle = Resources.Load<Sprite>("q_puzzles/puzzle1");
		puzzleSpriteRenderer.sprite = puzzle;
		puzzleSpriteRenderer.transform.position = new Vector3(0, 0, (float)0.01);
	}

	// void createNextPuzzleButton() {
	// 	GameObject go = new GameObject("Next Button");
	// 	go.layer = 8;
	// 	SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
	// 	Sprite next_button = Resources.Load<Sprite>("next_symbol");
	// 	renderer.sprite = next_button;
	// 	TapGesture tg = go.AddComponent<TapGesture>();
	// 	tg.Tapped += nextPuzzle;
	// 	tg.NumberOfTapsRequired = 3;
	// 	renderer.transform.position = new Vector3(7, (float)-3.75, 0);
	// 	renderer.transform.localScale = new Vector3((float)0.15, (float)0.15, (float)0.15);
	// 	go.AddComponent<Rigidbody2D>();
	// 	go.AddComponent<PolygonCollider2D>();
	// }

	// public void nextPuzzle(object sender, System.EventArgs e) {
	// 	Debug.Log("In next puzzle");
	// 	puzzleNumber++;
	// 	puzzleSpriteRenderer.sprite = Resources.Load<Sprite>("puzzles/puzzle" + puzzleNumber);
	// }
}
