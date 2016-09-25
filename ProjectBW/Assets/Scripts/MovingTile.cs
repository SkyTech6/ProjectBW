using UnityEngine;
using System.Collections;

public class MovingTile : MonoBehaviour {

	public Transform pointA;
	public Transform pointB;
	public float speed;
	GameObject player;

	void Update () 
	{
	
	}

	void OnTriggerEnter2D()
	{
		player.transform.parent = this.transform;
	}

	void OnTriggerExit2D()
	{
		player.transform.parent = null;
	}
		
	IEnumerator Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		while (true) {
			yield return StartCoroutine(MoveObject(transform, (new Vector3(pointA.position.x, pointA.position.y)), (new Vector3(pointB.position.x, pointB.position.y)), speed));
			yield return StartCoroutine(MoveObject(transform, (new Vector3(pointB.position.x, pointB.position.y)), (new Vector3(pointA.position.x, pointA.position.y)), speed));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}