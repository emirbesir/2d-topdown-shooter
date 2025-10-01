using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerInputHandler playerInput;
    [Header("Config")]
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = playerInput.GetMoveInputNormalized() * moveSpeed;
    }
}
