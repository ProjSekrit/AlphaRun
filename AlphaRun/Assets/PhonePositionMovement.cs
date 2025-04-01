using UnityEngine;

public class PhonePositionMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of movement
    public float laneWidth = 1.5f;  // Width of each lane (between -1.5f, 0f, 1.5f)
    public float smoothTime = 0.1f; // Time to smooth movement

    // These are the 3 fixed lanes: left, center, and right
    private float[] lanes = new float[] { -1.5f, 0f, 1.5f };
    private int currentLane = 1; // Default to center lane (index 1)

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    private float touchStartX;

    void Start()
    {
        targetPosition = transform.position; // Initialize the position to the center lane
    }

    void Update()
    {
        // Check if there is at least one touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began)
            {
                // Record the touch starting position
                touchStartX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the horizontal movement of the touch
                float touchDeltaX = touch.position.x - touchStartX;

                // If the movement is large enough, we change lanes
                if (touchDeltaX > 100f && currentLane < 2) // Move Right (next lane)
                {
                    currentLane++;
                    touchStartX = touch.position.x; // Reset the touch start position
                }
                else if (touchDeltaX < -100f && currentLane > 0) // Move Left (previous lane)
                {
                    currentLane--;
                    touchStartX = touch.position.x; // Reset the touch start position
                }
            }

            // Set the target position to the selected lane's position
            targetPosition.x = lanes[currentLane];
        }

        // Smoothly move the cube to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}



