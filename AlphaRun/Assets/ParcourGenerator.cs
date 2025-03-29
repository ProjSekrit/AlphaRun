using UnityEngine;
using System.Collections.Generic;

public class ParcourGenerator : MonoBehaviour
{
    public GameObject cube; // Your player cube
    public GameObject platformPrefab;
    public float spawnDistance = 5f;
    public float spacing = 2.5f;
    public float spawnInterval = 1.5f;
    public int maxPlatforms = 15;

    private Vector3 lastSpawnPosition;
    private float timer = 0f;
    private Queue<GameObject> spawnedPlatforms = new Queue<GameObject>();

    void Start()
    {
        lastSpawnPosition = cube.transform.position + cube.transform.forward * spawnDistance;

        // Spawn initial platforms
        for (int i = 0; i < 5; i++)
        {
            SpawnNextPlatform();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnNextPlatform();
            timer = 0f;
        }
    }

    void SpawnNextPlatform()
    {
        // Add some slight randomness in position (left/right or up/down)
        Vector3 offset = new Vector3(
            Random.Range(-0.5f, 0.5f), // Left/right wobble
            0,
            spacing + Random.Range(-0.2f, 0.2f) // Slight random forward spacing
        );

        Vector3 spawnPos = lastSpawnPosition + offset;

        GameObject platform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        spawnedPlatforms.Enqueue(platform);
        lastSpawnPosition = spawnPos;

        // Optional: Limit number of spawned platforms
        if (spawnedPlatforms.Count > maxPlatforms)
        {
            Destroy(spawnedPlatforms.Dequeue());
        }
    }
}
