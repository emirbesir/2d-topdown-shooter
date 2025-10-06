using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private MovementConfig _movementConfig;
    private Transform _target;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void InitializeEnemy(Vector3 spawnPosition, Transform targetTransform)
    {
        transform.position = spawnPosition;
        _target = targetTransform;
    }

    private void FixedUpdate()
    {
        if (_target == null)
        {
            Debug.LogError("Target is not assigned for EnemyMovement.");
            return;
        }
        if (_movementConfig == null)
        {
            Debug.LogError("MovementConfig is not assigned for EnemyMovement.");
            return;
        }

        Vector2 direction = (_target.position - transform.position).normalized;
        _rb.linearVelocity = direction * _movementConfig.MoveSpeed;
    }
}
