using UnityEngine;
using System.Collections.Generic;

public class ParcourGenerator : MonoBehaviour
{
    public GameObject cube;                  
    public GameObject platformPrefab;       
    public float platformLength = 2f;     
    public float spawnInterval = 1.5f;     
    public int maxPlatforms = 10;           

    private Vector3 lastSpawnPosition;
    private float timer = 0f;
    private Queue<GameObject> spawnedPlatforms = new Queue<GameObject>();

void Start()
{
    
    CleanupPlatforms();

    
    Vector3 initialOffset = new Vector3(0, -0.1f, -0.5f); 
    lastSpawnPosition = cube.transform.position + initialOffset;

    
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

    if (spawnedPlatforms.Count > maxPlatforms)
    {
        Destroy(spawnedPlatforms.Dequeue());
    }
}

}

