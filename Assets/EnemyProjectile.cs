using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                player.Respawn();
            }
            Destroy(gameObject);
        }

        // Destruir si choca con otra cosa (opcional)
        if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
