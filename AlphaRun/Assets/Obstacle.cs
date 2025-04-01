using UnityEngine;
using UnityEngine.SceneManagement;

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
            Debug.Log("💥 Player hit by obstacle!");
            SceneManager.LoadSceneAsync(1);

    }
}
