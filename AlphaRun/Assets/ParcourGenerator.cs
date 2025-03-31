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
        lastSpawnPosition.x = 0;
        lastSpawnPosition.y = 0;
        lastSpawnPosition.z = 0;

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

        lastSpawnPosition.x += spawnDistance;

        Vector3 spawnPos = lastSpawnPosition;

        GameObject platform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);

        Moving movingScript = platform.GetComponent<Moving>();
        if (movingScript != null)
        {
            movingScript.Initialize(cube.transform); // or ARCamera.transform
        }

        spawnedPlatforms.Enqueue(platform);
        lastSpawnPosition = spawnPos;

        // Optional: Limit number of spawned platforms
        if (spawnedPlatforms.Count > maxPlatforms)
        {
            Destroy(spawnedPlatforms.Dequeue());
        }
    }
}
