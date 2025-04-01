using UnityEngine;

public class Moving : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public bool shouldMove = true;

    private Transform target;

    void Start()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void Update()
    {
        if (!shouldMove) return;

        
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}




