using UnityEngine;

public class EnemyKillable : MonoBehaviour
{
    public float stompForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Ver si el contacto fue desde arriba
                Vector2 normal = collision.GetContact(0).normal;
                if (normal.y <= -0.5f) // Desde arriba
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, stompForce);
                    Destroy(gameObject);
                }
                else
                {
                    // Si no fue desde arriba, el jugador muere
                    collision.collider.GetComponent<PlayerRespawn>()?.Respawn();
                }
            }
        }
    }
}
