using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private GameInput gameInput;
    private Vector2 moveInput;

    private void Awake()
    {
        gameInput = new GameInput();
    }

    private void OnEnable()
    {
        gameInput.Enable();
    }

    private void OnDisable()
    {
        gameInput.Disable();
    }

    private void Update()
    {
        moveInput = gameInput.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMoveInputNormalized()
    {
        return moveInput.normalized;
    }
}
