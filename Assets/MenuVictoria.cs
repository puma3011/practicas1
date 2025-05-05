using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoria : MonoBehaviour
{
    public void CargarSiguienteNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SalirJuego()
    {
        Time.timeScale = 1f;
        Application.Quit();

        // Si estás en el editor:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
