using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Punto de respawn")]
    public Transform spawnPoint;

    [Header("Opcional: caer por debajo de…")]
    public float fallThresholdY = -30f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y < fallThresholdY)
            Respawn();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
            Respawn();
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = spawnPoint.position;
    }

    public void UpdateSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
