using UnityEngine;

using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject player;
    public float speed = 2f;
    protected Transform target;

    // Call this to assign the target (e.g., the cube or AR camera)
    public virtual void Initialize(Transform targetTransform)
    {
        target = targetTransform;
    }

    public void Start()
    {
        Initialize(player.transform);
    }

    protected virtual void Update()
    {
        if (target == null) return;

        // Move toward the target (e.g., player/cube)
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}



