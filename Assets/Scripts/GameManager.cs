using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool gameOverActivo = false;
    private bool ganasteActivo = false;
    public static GameManager Instance;
    public GameObject gameOverPanel;
    public GameObject botonPausa;
    public TextMeshProUGUI textGameover;
    public Button botonReiniciar;
    public Button botonSalir;
    void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        
        if (botonReiniciar != null)
        {
            botonReiniciar.onClick.AddListener(ReiniciarJuego);
        }

        if (botonSalir != null)
        {
            botonSalir.onClick.AddListener(SalirJuego);
        }
    }

    public void GameOver()
    {
        if (gameOverActivo) return;
        gameOverActivo = true;
        if (gameOverPanel != null)
        {   
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            botonPausa.SetActive(false);
        }
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     
    public void SalirJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}