using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _damage;
    private float _speed;
    private Vector2 _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print($"{collision.gameObject.name} has been hit with {_damage} damage!");
    }

    public void InitializeBullet(float damage, float speed, Vector2 direction)
    {
        _damage = damage;
        _speed = speed;
        _direction = direction;
    }
}
