using UnityEngine;

public class Movimiento_personaje : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float move;
    private bool isGrounded;
    public float velocidad = 2;
    public float jumpForce = 4;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move*velocidad, rb2D.linearVelocity.y);
        
        if (move != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
    
}
