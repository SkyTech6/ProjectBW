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
		}
	}

	void AssignInitialColor()
	{
		if (currentColor == "b") {
			sr.color = GameManager.cBlack;
			gameObject.layer = 11;
		} else if (currentColor == "w") {
			sr.color = GameManager.cWhite;
			gameObject.layer = 10;
		}
	}
}