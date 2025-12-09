using UnityEngine;

public class Efecto_parallax : MonoBehaviour
{
    private Material parallaxMaterial;
    private Transform player;
    private float lastPlayerX;
    public float parallaxMultiplier = 0.1f;

    void Start()
    {
        parallaxMaterial = GetComponent<Renderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerX = player.position.x;   
    }

    void Update()
    {
        float deltaX = player.position.x - lastPlayerX;
        parallaxMaterial.mainTextureOffset += new Vector2(deltaX * parallaxMultiplier, 0);
        lastPlayerX = player.position.x;
    }
}
