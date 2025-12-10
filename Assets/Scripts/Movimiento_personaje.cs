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
    public float velocidad = 3;
    public float jumpForce = 6;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    public TMP_Text textMonedas;
    public AudioSource audioSource;
    public AudioClip barrilClip;
    public AudioClip monedaClip;
    public AudioClip damageClip;
    public ParticleSystem particulaMove;
    

    void CrearParticulasMove()
    {
        if (Mathf.Abs(move) > 0.1f && isGrounded)
        {
            if (!particulaMove.isPlaying)
            {
                particulaMove.Play();
            }
        }
        else
        {
            if (particulaMove.isPlaying)
            {
                particulaMove.Stop();
            }
        }
    }

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
        CrearParticulasMove();
        
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
            audioSource.PlayOneShot(monedaClip);
            Destroy(collision.gameObject);
            monedas++;
            textMonedas.text = monedas.ToString();
        } 

        if (collision.transform.CompareTag("ZonaMuerte"))
        {
            audioSource.PlayOneShot(damageClip);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        } 

        if (collision.transform.CompareTag("Lanzas"))
        {
            audioSource.PlayOneShot(damageClip);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
            
        }

        if (collision.transform.CompareTag("Barril"))
        {
            audioSource.PlayOneShot(barrilClip);
            Vector2 knockbackDir = (rb2D.position - (Vector2)collision.transform.position).normalized;
            rb2D.linearVelocity = Vector2.zero;
            rb2D.AddForce(knockbackDir * 6, ForceMode2D.Impulse);

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