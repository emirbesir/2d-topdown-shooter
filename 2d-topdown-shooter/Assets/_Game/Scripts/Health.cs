using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(0, health - damage);

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
