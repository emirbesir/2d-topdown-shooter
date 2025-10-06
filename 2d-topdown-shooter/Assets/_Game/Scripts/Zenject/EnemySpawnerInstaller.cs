using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EnemySpawnerInstaller", menuName = "Installers/EnemySpawnerInstaller")]
public class EnemySpawnerInstaller : ScriptableObjectInstaller<EnemySpawnerInstaller>
{
    [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;

    public override void InstallBindings()
    {
        Container.Bind<EnemySpawnerConfig>().FromInstance(_enemySpawnerConfig).AsSingle();
    }
}
