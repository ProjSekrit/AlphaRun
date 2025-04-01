using UnityEngine;
using System.Collections;


public class PhonePositionMovement : MonoBehaviour
{
    public Transform arCamera;         // Assign your AR Camera in the Inspector
    public float sensitivity = 1f;
    public float laneWidth = 1.5f;
    public float smoothSpeed = 5f;

    private Vector3 initialCameraPos;
    private Vector3 targetPos;

void Start()
{
    initialCameraPos = arCamera.position;
}







    void Update()
    {
        // Calculate movement based on how far the phone moved since start
        float deltaX = (arCamera.position.x - initialCameraPos.x) * sensitivity;
        float deltaY = (arCamera.position.y - initialCameraPos.y) * sensitivity;

        // Snap to nearest lane on X axis
        float snappedX = Mathf.Round(deltaX / laneWidth) * laneWidth;
        snappedX = Mathf.Clamp(snappedX, -laneWidth, laneWidth);

        // Y only goes up
        float moveY = Mathf.Max(0f, deltaY);

        // Target position updates smoothly
        targetPos = new Vector3(snappedX, moveY, 0f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, smoothSpeed * Time.deltaTime);
    }
}

