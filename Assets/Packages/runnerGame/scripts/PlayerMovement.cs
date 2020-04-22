using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

public float moveSpeed;
public float jumpHeight;

public Transform groundCheck;
public float groundCheckRadius;
public LayerMask whatIsGround;
private bool grounded;

Animator animator;

// Use this for initialization
void Start () {
    grounded = true;
    animator = GetComponent<Animator>();
}

// Update is called once per frame
void Update () {
grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
float x = SimpleInput.GetAxis("Horizontal");
float y = SimpleInput.GetAxis("Vertical");

if ((Input.GetKeyDown (KeyCode.W) || y > 0) && grounded) {
GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
}

if (Input.GetKey (KeyCode.D) || x > 0) {
GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
GetComponent<Rigidbody2D>().transform.localScale = new Vector3(1,1,1);
}

if (Input.GetKey (KeyCode.A) || x < 0) {
GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
GetComponent<Rigidbody2D>().transform.localScale = new Vector3(-1,1,1);
}

animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
animator.SetFloat("YSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
}
}
