using UnityEngine;

public class PhoneMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust speed as needed
    public float smoothing = 0.1f; // Smooth movement for a better experience

    private Vector3 targetPosition; // The position the cube will move to
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // Initialize the target position to the current position
        targetPosition = transform.position;
    }

    void Update()
    {
        // Get phone's accelerometer input (X and Y axis)
        float moveX = Input.acceleration.x; // Left-Right movement (X axis)
        float moveY = Input.acceleration.y; // Up-Down movement (Y axis)

        // Move the player based on the accelerometer values
        targetPosition.x += moveX * moveSpeed * Time.deltaTime;
        targetPosition.y += moveY * moveSpeed * Time.deltaTime;

        // Smoothly move the player toward the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
    }
}


