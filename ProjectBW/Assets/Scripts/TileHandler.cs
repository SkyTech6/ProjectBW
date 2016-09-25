using UnityEngine;
using System.Collections;

public class TileHandler : MonoBehaviour {

	SpriteRenderer sr;
	PlayerController pc;

	public string currentColor;

	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();	
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		AssignInitialColor ();
	}

	public void FlipColor()
	{
		if (currentColor == "b") {
			sr.color = GameManager.cWhite;
			gameObject.layer = 10;
			currentColor = "w";
		} else if (currentColor == "w") {
			sr.color = GameManager.cBlack;
			gameObject.layer = 11;
			currentColor = "b";
		} else {
		}
	}

	void OnTriggerExit2D()
	{
		if (currentColor == "b" && pc.color == "w") {
			sr.color = GameManager.cWhite;
			gameObject.layer = 10;
			currentColor = "w";
		} else if (currentColor == "w" && pc.color == "b") {
			sr.color = GameManager.cBlack;
			gameObject.layer = 11;
			currentColor = "b";
		} else {
		}
	}

	void OnTriggerEnter2D()
	{
		if(currentColor == "g")
			pc.flipColor ();
	}

	void AssignInitialColor()
	{
		if (currentColor == "b") {
			sr.color = GameManager.cBlack;
			gameObject.layer = 11;
		} else if (currentColor == "w") {
			sr.color = GameManager.cWhite;
			gameObject.layer = 10;
		} else if (currentColor == "g") {
			sr.color = Color.gray;
			gameObject.layer = 0;
		}
	}
}