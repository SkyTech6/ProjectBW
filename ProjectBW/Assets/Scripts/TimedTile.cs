using UnityEngine;
using System.Collections;

public class TimedTile : MonoBehaviour {

	TileHandler th;
	public float changeTime;

	void Start () 
	{
		th = gameObject.GetComponent<TileHandler> ();
		StartCoroutine (Timer ());
	}

	void Update () 
	{
	
	}

	private IEnumerator Timer()
	{
		while (true) 
		{
			yield return new WaitForSeconds (changeTime);
			th.FlipColor ();
		}
	}
}
