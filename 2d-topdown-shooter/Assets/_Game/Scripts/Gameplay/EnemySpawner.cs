using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private IPool<EnemyMovement> _enemyPool;
    private EnemySpawnerConfig _enemySpawnerConfig;
    private Transform _playerTransform;
    private float _lastSpawnTime;

    [Inject]
    private void Constructor(IPool<EnemyMovement> enemyPool, EnemySpawnerConfig enemySpawnerConfig, PlayerMovement playerMovement)
    {
        _enemyPool = enemyPool;
        _enemySpawnerConfig = enemySpawnerConfig;
        _playerTransform = playerMovement.transform;
    }

    private void Start()
    {
        _lastSpawnTime = -_enemySpawnerConfig.SpawnInterval;
    }

    private void Update()
    {
        if (_enemyPool == null || _enemySpawnerConfig == null || _playerTransform == null)
        {
            Debug.LogError("Enemy Pool, Enemy Spawner Config or Player Transform not assigned!");
            return;
        }

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (Time.time <= _lastSpawnTime + _enemySpawnerConfig.SpawnInterval) return;

        EnemyMovement enemyMovement = _enemyPool.GetObject();
        _lastSpawnTime = Time.time;
        Vector3 enemySpawnPosition = GetRandomSpawnPosition();
        enemyMovement.InitializeEnemy(enemySpawnPosition, _playerTransform);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = _playerTransform.position + (Vector3)(randomDirection * _enemySpawnerConfig.SpawnRadius);
        return spawnPosition;
    }
}
