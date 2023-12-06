
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{[SerializeField] private float speed;
  private Rigidbody2D body;
	public Animator animator;

  private void Awake ()
  {
	  body = GetComponent<Rigidbody2D>();
  }

  private void Update ()

  {
		

	  body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (Input.GetKey (KeyCode.Space))
	  body.velocity = new Vector2(body.velocity.x, speed); 
  }
}
