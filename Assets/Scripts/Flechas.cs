using UnityEngine;

public class Flechas : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
           
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direccion = new Vector2(transform.position.x, 0);
            collision.gameObject.GetComponent<Movimiento_personaje>().RecibeDamage(direccion);
            collision.gameObject.GetComponent<Movimiento_personaje>().PerderVida();
        }
    }
}
