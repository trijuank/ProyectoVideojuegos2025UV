using UnityEngine;
using UnityEngine.SceneManagement;

public class PusarJuego : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegoPausado = false;
    
    public void ReanudarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void PausarJuego()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

        public void SalirJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
