using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private IWeapon _currentWeapon;

    [Inject]
    public void Constructor(IPlayerInput playerInput, IWeapon startingWeapon)
    {
        _playerInput = playerInput;
        _currentWeapon = startingWeapon;
    }

    private void OnEnable()
    {
        _playerInput.OnAttack += HandleAttack;
    }

    private void OnDisable()
    {
        _playerInput.OnAttack -= HandleAttack;
    }

    private void HandleAttack()
    {
        _currentWeapon.Shoot(_playerInput.GetMouseWorldPosition());
    }
}
