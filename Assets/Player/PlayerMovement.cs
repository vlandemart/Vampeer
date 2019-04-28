using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Rigidbody2D vampyr;
	[SerializeField]
	private float speed = 6f;
	private Animator animator;


    void Start()
    {
        vampyr = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
		Vector3 mov = new Vector3(moveVelocity.x, moveVelocity.y);
		transform.position += mov * Time.deltaTime;
		animator.SetBool("Walk", moveVelocity != Vector2.zero);
    }

    private void FixedUpdate()
    {
        //vampyr.MovePosition(vampyr.position + moveVelocity * Time.fixedDeltaTime);
    }
}
