using Zenject;
using UnityEngine;

public class ObjectPoolInstaller : MonoInstaller
{   
    [SerializeField] private BulletPool _bulletPool;

    public override void InstallBindings()
    {
        Container.Bind<IPool<Bullet>>().FromInstance(_bulletPool).AsSingle();
    }
}
