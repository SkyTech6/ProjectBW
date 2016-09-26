using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	SpriteRenderer sr;
	PlayerController pc;

	public string sceneToLoad;

	public string playerColorMatch = "b";

	// Use this for initialization
	void Start () 
	{
		sr = gameObject.GetComponent<SpriteRenderer> ();
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		if (playerColorMatch == "b")
			sr.color = GameManager.cBlack;
		else if (playerColorMatch == "w")
			sr.color = GameManager.cWhite;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D()
	{
		if (pc.color == playerColorMatch) {
			StartCoroutine (NextLevel ());
		}
	}

	IEnumerator NextLevel()
	{
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene(sceneToLoad);
	}
}