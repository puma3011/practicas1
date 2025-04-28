using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJuego()
    {
        // Cargar la escena del juego (aseg�rate de a�adirla en el Build Settings)
        SceneManager.LoadScene("Jmp King");
    }

    public void Opciones()
    {
        // Aqu� puedes cargar una nueva escena de opciones o mostrar un panel
        Debug.Log("Opciones seleccionadas");
    }

    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();

        // Esto no se notar� en el editor, s�lo en el juego compilado.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
