using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDamage;
    [SerializeField] private LayerMask _enemyMask;
    private float _startDirection = 0;
    private InputReader _inputReader;

    public event Action OnAttack;

    public void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        if (_inputReader.GetIsAttack())
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