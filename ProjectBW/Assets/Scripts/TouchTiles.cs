using UnityEngine;
using System.Collections;

public class TouchTiles : MonoBehaviour {

	SpriteRenderer sr;
	TileHandler th;

	// Use this for initialization
	void Start () 
	{
		sr = gameObject.GetComponent<SpriteRenderer> ();
		th = gameObject.GetComponent<TileHandler> ();
	}

	void OnTriggerEnter2D()
	{
		StartCoroutine (ColorFlash ());
	}

	private IEnumerator ColorFlash()
	{
		if (th.currentColor == "b") {
			sr.color = GameManager.cWhite;
			yield return new WaitForSeconds (0.3f);
			sr.color = GameManager.cBlack;
			yield return new WaitForSeconds (0.3f);
			sr.color = GameManager.cWhite;
			yield return new WaitForSeconds (0.3f);
			sr.color = GameManager.cBlack;
			yield return new WaitForSeconds (0.3f);
			th.FlipColor ();
		} else if (th.currentColor == "w") {
			sr.color = GameManager.cBlack;
			yield return new WaitForSeconds (0.3f);
			sr.color = GameManager.cWhite;
			yield return new WaitForSeconds (0.3f);
			sr.color = GameManager.cBlack;
			yield return new WaitForSeconds (0.3f);
			sr.color = GameManager.cWhite;
			yield return new WaitForSeconds (0.3f);
			th.FlipColor ();
		}
	}
}