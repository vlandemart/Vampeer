using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public float speed;
    private Rigidbody2D vampyr;


    // Start is called before the first frame update
    void Start()
    {
        vampyr = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        vampyr.MovePosition(vampyr.position + moveVelocity * Time.fixedDeltaTime);
    }
}
