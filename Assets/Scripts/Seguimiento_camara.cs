using UnityEngine;

public class Seguimiento_camara : MonoBehaviour
{
    public Transform target;
    
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
