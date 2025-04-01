using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static float currentSpeed = 2f;
    public float startSpeed = 2f;
    public float maxSpeed = 10f;
    public float accelerationRate = 0.1f; 

    void Start()
    {
        currentSpeed = startSpeed;
    }

    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += accelerationRate * Time.deltaTime;
        }
    }
}
