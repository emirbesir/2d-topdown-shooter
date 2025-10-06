using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MovementInstaller", menuName = "Installers/MovementInstaller")]
public class MovementInstaller : ScriptableObjectInstaller<MovementInstaller>
{
    [SerializeField] private MovementConfig _playerMovementConfig;

    public override void InstallBindings()
    {
        Container.Bind<MovementConfig>().FromInstance(_playerMovementConfig).AsSingle();
    }
}
