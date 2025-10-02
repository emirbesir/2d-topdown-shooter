using System.Collections;
using UnityEngine;
using Zenject;

public class ProjectileWeapon : MonoBehaviour, IWeapon
{
    [Header("Weapon Config")]
    [SerializeField] private WeaponConfig _weaponConfig;
    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private IPool<Bullet> _bulletPool;
    private int _currentBulletInMag;
    private int _totalBullet;
    private float _lastShootTime;
    private bool _isReloading;

    [Inject]
    public void Constructor(IPool<Bullet> bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private void Start()
    {
        InitializeWeapon();
    }

    public void InitializeWeapon()
    {
        _currentBulletInMag = _weaponConfig.BulletInMag;
        _totalBullet = _weaponConfig.TotalBullets;
        _spriteRenderer.sprite = _weaponConfig.Sprite;
        _lastShootTime = -_weaponConfig.RateOfFire;
    }

    public void Reload()
    {
        if (_isReloading || _totalBullet <= 0 || _currentBulletInMag == _weaponConfig.BulletInMag) return;
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_weaponConfig.ReloadTime);

        int bulletsToReload = _weaponConfig.BulletInMag - _currentBulletInMag;

        if (_totalBullet >= bulletsToReload)
        {
            _currentBulletInMag += bulletsToReload;
            _totalBullet -= bulletsToReload;
        }
        else
        {
            _currentBulletInMag += _totalBullet;
            _totalBullet = 0;
        }
        
        _isReloading = false;
    }

    public void Shoot(Vector2 targetPosition)
    {
        if (_isReloading) return;

        if (_currentBulletInMag <= 0)
        {
            Reload();
            return;
        }

        if (Time.time - _lastShootTime < 1f / _weaponConfig.RateOfFire) return;

        Bullet bullet = _bulletPool.GetObject();
        _lastShootTime = Time.time;
        _currentBulletInMag--;

        Vector2 weaponPosition = transform.position;
        Vector2 shootDirectionNormalized = (targetPosition - weaponPosition).normalized;
        bullet.InitializeBullet(_weaponConfig.Damage, _weaponConfig.BulletSpeed, shootDirectionNormalized, weaponPosition, _bulletPool);
    }
}
