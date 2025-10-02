using UnityEngine;
using Zenject;

public class WeaponPositionUpdater : MonoBehaviour
{
    private const float WEAPON_POSITION_OFFSET = 0.5f;
    
    private IPlayerInput _playerInput;

    [Inject]
    public void Constructor(IPlayerInput playerInput)
    {
        _playerInput = playerInput;
    }

    private void Update()
    {
        MoveWeapon();
    }

    private void MoveWeapon()
    {
        Vector2 mousePosition = _playerInput.GetMouseWorldPosition();
        Vector2 aimDirectionNormalized = (mousePosition - (Vector2)transform.parent.position).normalized;
        transform.localPosition = aimDirectionNormalized * WEAPON_POSITION_OFFSET;

        float angle = Mathf.Atan2(aimDirectionNormalized.y, aimDirectionNormalized.x) * Mathf.Rad2Deg - 90;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
