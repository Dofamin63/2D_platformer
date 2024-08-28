using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _delayAttack;

    private Coroutine _coroutine;
    private bool _canUsingSkill = true;

    public void TryAttack(Player player)
    {
        if (_canUsingSkill)
        {
            _canUsingSkill = false;
            player.Health.TakeDamage(_attackDamage);
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(_delayAttack);
        _canUsingSkill = true;
    }
}