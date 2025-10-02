using Zenject;
using UnityEngine;

public class ObjectPoolInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPool<Bullet>>().FromComponentInHierarchy().AsSingle();
    }
}
