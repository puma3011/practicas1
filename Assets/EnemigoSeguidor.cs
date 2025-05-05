using UnityEngine;

public class EnemigoSeguidor : MonoBehaviour
{
    public Transform jugador;                  // Asigna el jugador en el Inspector
    public float velocidad = 2f;               // Velocidad de movimiento
    public float rangoDeteccion = 5f;          // Distancia m�xima para detectar al jugador

    private Rigidbody2D rb;
    private JumpKingMovement scriptJugador;    // Referencia al script del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Buscar al jugador por etiqueta
        if (jugador == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            if (obj != null)
            {
                jugador = obj.transform;
                scriptJugador = jugador.GetComponent<JumpKingMovement>();
            }
        }
    }


    void Update()
    {
        if (jugador == null || scriptJugador == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia < rangoDeteccion && scriptJugador.EstaEnSuelo)
        {
            // Direcci�n horizontal hacia el jugador
            float direccionX = Mathf.Sign(jugador.position.x - transform.position.x);
            rb.linearVelocity = new Vector2(direccionX * velocidad, rb.linearVelocity.y);

            // Voltear sprite (opcional)
            Vector3 escala = transform.localScale;
            escala.x = direccionX < 0 ? -1 : 1;
            transform.localScale = escala;
        }
        else
        {
            // Detener movimiento si el jugador est� en el aire o fuera de rango
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    // Dibuja el rango de detecci�n del enemigo con Gizmos en la escena
    void OnDrawGizmos()
    {
        if (jugador == null) return;

        // Dibuja un c�rculo para mostrar el rango de detecci�n
        Gizmos.color = Color.red; // Color rojo para el rango de detecci�n
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion); // Dibuja el c�rculo de detecci�n
    }
}
