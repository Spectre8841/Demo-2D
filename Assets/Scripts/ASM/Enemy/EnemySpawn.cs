using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn
    public int numberOfEnemies = 5;  // Number of enemies to spawn each time
    public Vector2 mapMinBounds;  // Bottom-left corner of the map (min X, min Y)
    public Vector2 mapMaxBounds;  // Top-right corner of the map (max X, max Y)
    [SerializeField] private float spawnInterval = 10.0f;  // Time between each spawn wave

    private void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(spawnInterval);  // Wait for the specified interval before spawning again
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        float spawnX = Random.Range(mapMinBounds.x, mapMaxBounds.x);
        float spawnY = Random.Range(mapMinBounds.y, mapMaxBounds.y);
        return new Vector2(spawnX, spawnY);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(mapMinBounds.x, mapMinBounds.y), new Vector2(mapMinBounds.x, mapMaxBounds.y));
        Gizmos.DrawLine(new Vector2(mapMinBounds.x, mapMaxBounds.y), new Vector2(mapMaxBounds.x, mapMaxBounds.y));
        Gizmos.DrawLine(new Vector2(mapMaxBounds.x, mapMaxBounds.y), new Vector2(mapMaxBounds.x, mapMinBounds.y));
        Gizmos.DrawLine(new Vector2(mapMaxBounds.x, mapMinBounds.y), new Vector2(mapMinBounds.x, mapMinBounds.y));
    }
}
