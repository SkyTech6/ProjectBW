using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Button startButton;
	public Button exitButton;
	public string sceneToLoad;

	void Start () 
	{
		startButton.onClick.AddListener (() => StartGame ());
		exitButton.onClick.AddListener (() => ExitGame ());
	}

	void StartGame()
	{
		SceneManager.LoadScene (sceneToLoad);
	}

	void ExitGame()
	{
		Application.Quit ();
	}
}
