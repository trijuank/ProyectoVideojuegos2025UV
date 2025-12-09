using UnityEngine;

public class Seguimiento_camara : MonoBehaviour
{
    public Transform target;
    public float velocidadCamara = 0.125f;
    public Vector3 desplazamiento;
    
    private void LateUpdate()
    {
        Vector3 posicionDeseada = target.position + desplazamiento;
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);
        transform.position = posicionSuavizada;
    }
}
