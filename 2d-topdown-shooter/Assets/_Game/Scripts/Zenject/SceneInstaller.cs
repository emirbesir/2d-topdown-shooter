using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPlayerInput>().To<PlayerInputHandler>().FromComponentInHierarchy().AsSingle();
    }
}
