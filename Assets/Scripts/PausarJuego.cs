using UnityEngine;
using UnityEngine.SceneManagement;

public class PusarJuego : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject botonPausa;
    public bool juegoPausado = false;
    
    public void ReanudarJuego()
    {
        menuPausa.SetActive(false);
        botonPausa.SetActive(true);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void PausarJuego()
    {
        menuPausa.SetActive(true);
        botonPausa.SetActive(false);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

        public void SalirJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
