using UnityEngine;

public class MetaFinal : MonoBehaviour
{
    public GameObject panelVictoria; // Panel con mensaje y botones

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f; // Pausa el juego
            panelVictoria.SetActive(true); // Muestra el panel de victoria
        }
    }
}
