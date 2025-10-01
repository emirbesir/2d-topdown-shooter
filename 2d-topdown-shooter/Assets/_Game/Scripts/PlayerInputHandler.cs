using UnityEngine;

public class PlayerInputHandler : MonoBehaviour, IPlayerInput
{
    private GameInput _gameInput;
    private Vector2 _moveInput;

    private void Awake()
    {
        _gameInput = new GameInput();
    }

    private void OnEnable()
    {
        _gameInput.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    private void Update()
    {
        _moveInput = _gameInput.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMoveInput()
    {
        return _moveInput;
    }
}
