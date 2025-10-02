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
    private Coroutine _deactivateCoroutine;
    private bool _isInitialized;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void InitializeBullet(float damage, float speed, Vector2 direction, Vector2 startingPosition, IPool<Bullet> pool)
    {
        _damage = damage;
        _speed = speed;
        _direction = direction;
        transform.position = startingPosition;
        _bulletPool = pool;
        _isInitialized = true;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void OnEnable()
    {
        _deactivateCoroutine = StartCoroutine(DeactivateAfterTime(TIME_TO_DEACTIVATE));
    }

    private void FixedUpdate()
    {
        if (!_isInitialized) return;
        
        _rb.linearVelocity = _direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
            ReturnToPool();
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        if (_deactivateCoroutine != null)
        {
            StopCoroutine(_deactivateCoroutine);
            _deactivateCoroutine = null;
        }
        _rb.linearVelocity = Vector2.zero;
        _bulletPool.ReturnObject(this);
    }
}
