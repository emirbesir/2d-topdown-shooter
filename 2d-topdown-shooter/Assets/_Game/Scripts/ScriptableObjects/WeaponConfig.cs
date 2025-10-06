using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    [Header("Weapon Appearance")]
    [SerializeField] private Sprite sprite;
    [Header("Weapon Stats")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float rateOfFire = 1f;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private int bulletInMag = 19;
    [SerializeField] private int additionalMagCount = 3;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private bool isAutomatic = false;
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;

    public Sprite Sprite => sprite;
    public float Damage => damage;
    public float RateOfFire => rateOfFire;
    public float BulletSpeed => bulletSpeed;
    public int BulletInMag => bulletInMag;
    public int TotalBullets => bulletInMag + bulletInMag * additionalMagCount;
    public float ReloadTime => reloadTime;
    public GameObject ProjectilePrefab => projectilePrefab;
    public bool IsAutomatic => isAutomatic;
}
