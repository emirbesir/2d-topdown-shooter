using Zenject;
using UnityEngine;

public class ObjectPoolInstaller : MonoInstaller
{   
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private EnemyPool _enemyPool;

    public override void InstallBindings()
    {
        Container.Bind<IPool<Bullet>>().FromInstance(_bulletPool).AsSingle();
        Container.Bind<IPool<EnemyMovement>>().FromInstance(_enemyPool).AsSingle();
    }
}
