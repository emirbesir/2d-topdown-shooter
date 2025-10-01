using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private IPlayerInput _playerInput;
    private MovementConfig _movementConfig;

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
        _rb.linearVelocity = _playerInput.GetMoveInput().normalized * _movementConfig.MoveSpeed;
    }
}
