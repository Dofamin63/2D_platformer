using UnityEngine;

[RequireComponent(typeof(Health))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _radius;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Tick()
    {
        IDamageable nearest = FindNearestEnemy();
        if (nearest == null) return;

        float damage = _damagePerSecond * Time.deltaTime;
        nearest.TakeDamage(damage);
        _health.Heal(damage);
    }

    private IDamageable FindNearestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyMask);
        IDamageable nearest = null;
        float minDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable enemy))
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemy;
                }
            }
        }

        return nearest;
    }
}