using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public float modifier;

	// Use this for initialization
	void Start () 
	{
		Camera.main.orthographicSize = modifier / Screen.width * Screen.height;
	}
}