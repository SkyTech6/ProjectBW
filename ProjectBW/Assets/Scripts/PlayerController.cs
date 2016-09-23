using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private string color = "w";
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

	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		groundMask = groundMaskB;
	}
	
	void FixedUpdate () 
	{
		Vector2 moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, rb.velocity.y);
		rb.velocity = moveDir;

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, radius, groundMask);

		if (Input.GetKeyDown (KeyCode.W)  && isGrounded) {
			rb.AddForce (new Vector2 (0, jumpHeight));
		}

		if (Input.GetMouseButtonDown (0))
			flipColor ();
	}

	void flipColor()

	{
		if (color == "w") {
			sr.color = GameManager.cBlack;
			gameObject.layer = 9;
			color = "b";
			groundMask = groundMaskB;
		} else if (color == "b") {
			sr.color = GameManager.cWhite;
			gameObject.layer = 8;
			color = "w";
			groundMask = groundMaskW;
		}

		GameManager.FlipWorld ();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (groundCheck.position, radius);
	}
}