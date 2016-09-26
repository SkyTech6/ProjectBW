using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fin : MonoBehaviour {

	public Button exitButton;

	void Start () 
	{
		exitButton.onClick.AddListener (() => ExitGame ());
	}

	void ExitGame()
	{
		Application.Quit ();
	}
}
