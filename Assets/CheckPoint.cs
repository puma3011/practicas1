using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawnScript = other.GetComponent<PlayerRespawn>();
            if (respawnScript != null)
            {
                respawnScript.UpdateSpawnPoint(transform);
            }
        }
    }
}
