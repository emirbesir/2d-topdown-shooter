using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private IWeapon _currentWeapon;
    private bool _isAutoFiring = false;

    [Inject]
    public void Constructor(IPlayerInput playerInput, IWeapon startingWeapon)
    {
        _playerInput = playerInput;
        _currentWeapon = startingWeapon;
    }

    private void OnEnable()
    {
        _playerInput.OnAttack += HandleAttackStart;
        _playerInput.OnAttackRelease += HandleAttackStop;
    }

    private void OnDisable()
    {
        _playerInput.OnAttack -= HandleAttackStart;
        _playerInput.OnAttackRelease -= HandleAttackStop;
    }

    private void Update()
    {
        if (_isAutoFiring && _currentWeapon.IsAutomatic())
        {
            HandleAttack();
        }
    }

    private void HandleAttackStart()
    {
        _isAutoFiring = true;
        HandleAttack(); // Shoot immediately when button is pressed
    }

    private void HandleAttackStop()
    {
        _isAutoFiring = false;
    }

    private void HandleAttack()
    {
        if (_currentWeapon == null || _playerInput == null)
        {
            Debug.LogError("CurrentWeapon or PlayerInput is not assigned.");
            return;
        }
        
        _currentWeapon.Shoot(_playerInput.GetMouseWorldPosition());
    }
}
