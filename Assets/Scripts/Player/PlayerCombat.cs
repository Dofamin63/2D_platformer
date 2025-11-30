using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDamage;
    [SerializeField] private LayerMask _enemyMask;
    private float _startDirection = 0;

    public event Action OnAttack;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Vector2 direction = transform.localScale.x > _startDirection ? Vector2.right : Vector2.left;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, _attackRange, _enemyMask);
        OnAttack?.Invoke();
        
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
                enemy.Health.TakeDamage(_attackDamage);
        }
    }
}