using UnityEngine;

public class Moving : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public bool shouldMove = true;

    private Transform target;

    void Start()
    {
        // Optional: Move towards player if needed
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void Update()
    {
        if (!shouldMove) return;

        // Default movement: move backward (toward player direction)
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}




