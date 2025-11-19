using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movimiento_personaje : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float move;
    private bool isGrounded;
    private Animator animator;
    private int monedas;
    public float velocidad = 2;
    public float jumpForce = 4;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    public TMP_Text textMonedas;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Moneda"))
        {
            Destroy(collision.gameObject);
            monedas++;
            textMonedas.text = monedas.ToString();
        } 

        if (collision.transform.CompareTag("Lanzas"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.transform.CompareTag("Barril"))
        {
            Vector2 knockbackDir = (rb2D.position - (Vector2)collision.transform.position).normalized;
            rb2D.linearVelocity = Vector2.zero;
            rb2D.AddForce(knockbackDir * 3, ForceMode2D.Impulse);

            BoxCollider2D[] colliders = collision.gameObject.GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D collider in colliders)
            {
                collider.enabled = false;
            }

            collision.GetComponent<Animator>().enabled = true;
            Destroy(collision.gameObject, 0.5f);
        }
    }
    
}
