using UnityEngine;

public class PhonePositionMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    
    public float laneWidth = 1.5f;  
    public float smoothTime = 0.1f; 

    
    private float[] lanes = new float[] { -1.5f, 0f, 1.5f };
    private int currentLane = 1; 

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    private float touchStartX;

    void Start()
    {
        targetPosition = transform.position; 
    }

    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)
            {
                
                touchStartX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
               
                float touchDeltaX = touch.position.x - touchStartX;

                
                if (touchDeltaX > 100f && currentLane < 2) 
                {
                    currentLane++;
                    touchStartX = touch.position.x; 
                }
                else if (touchDeltaX < -100f && currentLane > 0) 
                {
                    currentLane--;
                    touchStartX = touch.position.x; 
                }
            }

            
            targetPosition.x = lanes[currentLane];
        }

       
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}



