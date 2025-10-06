using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private MovementConfig _movementConfig;
    private Rigidbody2D _rb;

    [Inject]
    public void Construct(IPlayerInput playerInput, MovementConfig movementConfig)
    {
        _playerInput = playerInput;
        _movementConfig = movementConfig;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_playerInput == null || _movementConfig == null)
        {
            Debug.LogError("PlayerInput or MovementConfig is not assigned.");
            return;
        }

        Vector2 moveInput = _playerInput.MoveInput;

        MoveTowards(moveInput);
    }

    private void MoveTowards(Vector2 direction)
    {
        _rb.linearVelocity = direction.normalized * _movementConfig.MoveSpeed;
    }
}
