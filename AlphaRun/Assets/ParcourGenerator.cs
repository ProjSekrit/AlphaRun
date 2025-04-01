using UnityEngine;
using System.Collections.Generic;

public class ParcourGenerator : MonoBehaviour
{
    public GameObject cube;                  // Your player (should be at 0,0,0 initially)
    public GameObject platformPrefab;       // Your walkway prefab
    public float platformLength = 2f;       // Z-length of each platform
    public float spawnInterval = 1.5f;      // Time between platform spawns
    public int maxPlatforms = 10;           // Max number of active platforms

    private Vector3 lastSpawnPosition;
    private float timer = 0f;
    private Queue<GameObject> spawnedPlatforms = new Queue<GameObject>();

void Start()
{
    // 🧹 Clean up any old leftover platforms (from Edit mode or replay)
    CleanupPlatforms();

    // Start by placing a platform just behind and below the cube
    Vector3 initialOffset = new Vector3(0, -0.1f, -0.5f); // adjust if needed
    lastSpawnPosition = cube.transform.position + initialOffset;

    // Spawn a few starter platforms
    for (int i = 0; i < 5; i++)
    {
        SpawnNextPlatform();
    }
}
void CleanupPlatforms()
{
    GameObject[] oldPlatforms = GameObject.FindGameObjectsWithTag("Platform");

    foreach (GameObject p in oldPlatforms)
    {
        Destroy(p);
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
    Vector3 spawnOffset = new Vector3(0, 0, platformLength);
    Vector3 spawnPos = lastSpawnPosition + spawnOffset;

    // 👇 Force Y = 0 in spawn position
    spawnPos.y = 0f;

    GameObject platform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
    spawnedPlatforms.Enqueue(platform);
    lastSpawnPosition = spawnPos;
    PlatformCoinSpawner coinSpawner = platform.GetComponent<PlatformCoinSpawner>();
if (coinSpawner != null)
{
    coinSpawner.SpawnCoins();
    coinSpawner.SpawnObstacles();
}
else
{
    Debug.LogWarning("⚠️ No PlatformCoinSpawner found on " + platform.name);
}

    if (spawnedPlatforms.Count > maxPlatforms)
    {
        Destroy(spawnedPlatforms.Dequeue());
    }
}

}

