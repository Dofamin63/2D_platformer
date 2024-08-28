using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDamage;
    [SerializeField] private LayerMask _enemyMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRange, _enemyMask);

        foreach (Collider2D hit in colliders)
        {
            if (hit.TryGetComponent(out Enemy enemy))
            {
                enemy.Health.TakeDamage(_attackDamage);
            }
        }
    }
}