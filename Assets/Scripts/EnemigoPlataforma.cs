using UnityEngine;

public class EnemigoPlataforma : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidad;
    public LayerMask capaAbajo;
    public LayerMask capaEnfrente;
    public float distanciaAbajo;
    public float distanciaEnfrente;
    public Transform controladorAbajo;
    public Transform controladorEnfrente;
    public bool infoAbajo;
    public bool infoEnfrente;
    private bool mirandoDerecha = true;

    private void Update()
    {

        rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);
        infoEnfrente = Physics2D.Raycast(controladorEnfrente.position, transform.right, distanciaEnfrente, capaEnfrente);
        infoAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

        if (infoEnfrente || !infoAbajo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position + transform.up * -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorEnfrente.transform.position, controladorEnfrente.transform.position + transform.right * distanciaEnfrente);
    }
}
