using UnityEngine;

public class PlatformCoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject obstaclePrefab;

    public int maxCoins = 3;
    public int maxObstacles = 1;

    public float laneWidth = 1.5f;
    public float yOffset = 1f;
    public float platformLength = 10f;

    private float[] laneOffsets = new float[] { -1, 0, 1 };

    public void SpawnCoins()
    {
        int coinCount = Random.Range(1, maxCoins + 1);
        for (int i = 0; i < coinCount; i++)
        {
            float laneX = laneOffsets[Random.Range(0, laneOffsets.Length)] * laneWidth;
            float forwardZ = Random.Range(-platformLength / 2f + 1, platformLength / 2f - 1);

            Vector3 spawnPos = transform.position + new Vector3(laneX, yOffset, forwardZ);
            GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            coin.transform.localScale = Vector3.one;
        }
    }
public void SpawnObstacles()
{
    if (obstaclePrefab == null)
    {

        return;
    }

    int obstacleCount = Random.Range(1, maxObstacles + 1);
    

    float obstacleHeight = 1f;         
    float platformY = transform.position.y;
    float spawnY = platformY + obstacleHeight / 2f;

    for (int i = 0; i < obstacleCount; i++)
    {
        
        float laneX = laneOffsets[Random.Range(0, laneOffsets.Length)] * laneWidth;

        
        float forwardZ = Random.Range(-platformLength / 2f + 1f, platformLength / 2f - 1f);

        Vector3 spawnPos = transform.position + new Vector3(laneX, spawnY, forwardZ);

        GameObject obs = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        obs.transform.localScale = Vector3.one;
        Debug.DrawRay(spawnPos, Vector3.up * 2f, Color.red, 5f); 
    }
}



}


