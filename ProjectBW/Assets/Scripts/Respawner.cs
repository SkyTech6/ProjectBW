using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour {


	void Start () 
	{
	
	}
	

	void Update () 
	{

	}

	void OnTriggerEnter2D ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}