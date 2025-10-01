using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MovementInstaller", menuName = "Installers/MovementInstaller")]
public class MovementInstaller : ScriptableObjectInstaller<MovementInstaller>
{
    [SerializeField] private MovementConfig movementConfig;

    public override void InstallBindings()
    {
        Container.Bind<MovementConfig>().FromInstance(movementConfig).AsSingle();
    }
}
