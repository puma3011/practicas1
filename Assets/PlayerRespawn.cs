using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Punto de respawn")]
    public Transform spawnPoint;

    [Header("Opcional: caer por debajo de…")]
    public float fallThresholdY = -10f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Si cae muy abajo, también respawneá
        if (transform.position.y < fallThresholdY)
            Respawn();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si toca la zona de muerte, respawneá
        if (other.CompareTag("DeathZone"))
            Respawn();
    }

    public void Respawn()
    {
        // Detener toda velocidad
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        // Volver al punto de respawn
        transform.position = spawnPoint.position;

        // (Opcional) Resetear animaciones o estados
        // GetComponent<Animator>()?.Play("Idle");
    }
}
