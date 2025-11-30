using System;
using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _delayAttack;
    [SerializeField] private float _attackRange;

    private Coroutine _coroutine;
    private bool _canUsingSkill = true;
    public event Action OnAttack;

    public void TryAttack(Player player)
    {
        if (_canUsingSkill && IsPlayerInRange(player))
        {
            _canUsingSkill = false;
            OnAttack?.Invoke();
            player.Health.TakeDamage(_attackDamage);
            StartCoroutine(ResetAttack());
        }
    }

    private bool IsPlayerInRange(Player player)
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= _attackRange;
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(_delayAttack);
        _canUsingSkill = true;
    }
}