using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float destroyDelay = 5f; // Auto-destroy after it passes the player (optional)

    void Start()
    {
        // Optional: destroy obstacle after a few seconds
        Destroy(gameObject, destroyDelay);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("💥 Player hit by obstacle!");

            // TODO: Trigger your game over / damage logic
            // Example: other.GetComponent<PlayerHealth>().TakeDamage();

            // Optional: Destroy obstacle on collision
            // Destroy(gameObject);
        }
    }
}
