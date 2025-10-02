using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{   
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    [SerializeField] private ProjectileWeapon _projectileWeapon;

    public override void InstallBindings()
    {
        Container.Bind<IPlayerInput>().To<PlayerInputHandler>().FromInstance(_playerInputHandler).AsSingle();
        Container.Bind<IWeapon>().To<ProjectileWeapon>().FromInstance(_projectileWeapon).AsSingle();
    }
}
