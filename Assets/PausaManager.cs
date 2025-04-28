using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    public GameObject pausaPanel;  // El Panel de Pausa
    private bool juegoPausado = false;

    void Update()
    {
        // Detectar cuando se presiona la tecla P para pausar/despausar
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                ReanudarJuego(); // Si est� pausado, reanudar
            }
            else
            {
                PausarJuego(); // Si est� en juego, pausar
            }
        }
    }

    // Funci�n para pausar el juego
    public void PausarJuego()
    {
        pausaPanel.SetActive(true);  // Activar el panel de pausa
        Time.timeScale = 0f;         // Pausar el tiempo
        juegoPausado = true;
    }

    // Funci�n para reanudar el juego
    public void ReanudarJuego()
    {
        pausaPanel.SetActive(false); // Desactivar el panel de pausa
        Time.timeScale = 1f;         // Reanudar el tiempo
        juegoPausado = false;
    }

    // Funci�n para salir del juego
    public void SalirDelJuego()
    {
        Time.timeScale = 1f; // Asegurarse de reanudar el juego antes de salir
        Debug.Log("Saliendo del juego...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para detener el juego en el editor
#endif
    }
}
