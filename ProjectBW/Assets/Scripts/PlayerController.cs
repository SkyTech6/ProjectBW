﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public string color = "w";
	SpriteRenderer sr;
	Rigidbody2D rb;

	public int moveSpeed;
	public int jumpHeight;

	public Transform groundCheck;
	public float radius;
	public LayerMask groundMaskW;
	public LayerMask groundMaskB;
	public LayerMask groundMask;

	bool isGrounded;
	public bool grayMode = false;

	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		groundMask = groundMaskB;

		InitialColor ();
	}
	
	void Update () 
	{
		Vector2 moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, rb.velocity.y);
		rb.velocity = moveDir;

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, radius, groundMask);

		if (Input.GetKeyDown (KeyCode.W)  && isGrounded) {
			rb.AddForce (new Vector2 (0, jumpHeight));
		}

		if (!grayMode) {
			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.E))
				flipColor ();
		}
	}

	void InitialColor()
	{
		if (color == "b") {
			sr.color = GameManager.cBlack;
			gameObject.layer = 9;
		} else if (color == "w") {
			sr.color = GameManager.cWhite;
			gameObject.layer = 8;
		}

		ReassignGrounds ();
	}

	public void flipColor()

	{
		if (color == "w") {
			sr.color = GameManager.cBlack;
			gameObject.layer = 9;
			color = "b";
		} else if (color == "b") {
			sr.color = GameManager.cWhite;
			gameObject.layer = 8;
			color = "w";
		}
		ReassignGrounds ();
		//GameManager.FlipWorld ();
	}

	void ReassignGrounds()
	{
		if (color == "b")
			groundMask = groundMaskW;
		else if (color == "w")
			groundMask = groundMaskB;
	}
}