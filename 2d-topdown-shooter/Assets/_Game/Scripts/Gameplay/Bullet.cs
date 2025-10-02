using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{   
    private const float TIME_TO_DEACTIVATE = 3f;

    private IPool<Bullet> _bulletPool;
    private Rigidbody2D _rb;
    private float _damage;
    private float _speed;
    private Vector2 _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateAfterTime(TIME_TO_DEACTIVATE));
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable;

        if (collision.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.TakeDamage(_damage);
            print($"{collision.gameObject.name} has been hit with {_damage} damage!");
            _bulletPool.ReturnObject(this);
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        _bulletPool.ReturnObject(this);
    }

    public void InitializeBullet(float damage, float speed, Vector2 direction, Vector2 startingPosition, IPool<Bullet> pool)
    {
        _damage = damage;
        _speed = speed;
        _direction = direction;
        transform.position = startingPosition;
        _bulletPool = pool;
    }
}
