using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Configs/EnemySpawnerConfig")]
public class EnemySpawnerConfig : ScriptableObject
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _spawnRadius = 10f;

    public float SpawnInterval => _spawnInterval;
    public float SpawnRadius => _spawnRadius;
}
