using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnInterval = 2f;

    public float spawnX = 6f;
    public float minY = -1.8f;
    public float maxY = 1.8f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(
            spawnX,
            randomY,
            0f
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}