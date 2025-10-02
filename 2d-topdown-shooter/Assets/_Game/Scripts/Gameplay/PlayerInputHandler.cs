using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour, IPlayerInput
{
    private GameInput _gameInput;
    private Camera _mainCamera;
    private Mouse _mouse;
    private Vector2 _moveInput;

    public event Action OnAttack;
    public Vector2 MoveInput => _moveInput;

    private void Awake()
    {
        _gameInput = new GameInput();
        _mainCamera = Camera.main;
        _mouse = Mouse.current;

        if (_mainCamera == null)
        {
            Debug.LogError("Main Camera is not assigned in the scene.");
        }
        if (_mouse == null)
        {
            Debug.LogError("Mouse device is not found.");
        }
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

    public Vector2 GetMouseWorldPosition()
    {
        Vector2 screenPosition = _mouse.position.ReadValue();
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
        return new Vector2(worldPosition.x, worldPosition.y);
    }
}
