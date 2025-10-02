using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour, IPlayerInput
{
    private Camera _mainCamera;
    private GameInput _gameInput;
    private Vector2 _moveInput;

    public event Action OnAttack;

    private void Awake()
    {
        _gameInput = new GameInput();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.Player.Attack.performed += HandleAttack;
    }

    private void OnDisable()
    {
        _gameInput.Disable();
        _gameInput.Player.Attack.performed -= HandleAttack;
    }

    private void Update()
    {
        _moveInput = _gameInput.Player.Move.ReadValue<Vector2>();
    }

    private void HandleAttack(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }

    public Vector2 GetMoveInput()
    {
        return _moveInput;
    }

    public Vector2 GetMouseWorldPosition()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
        return new Vector2(worldPosition.x, worldPosition.y);
    }
}
