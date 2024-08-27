using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _delay;

    private WaitForSeconds _delayAttack;
    private Coroutine _coroutine;
    private bool _isCombat;

    public bool IsCombat => _isCombat;
    public Player Player { get; private set; }

    public bool CanSeePlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRange);

        foreach (Collider2D hit in colliders)
        {
            if (hit.TryGetComponent(out Player player))
            {
                Player = player;
                _isCombat = true;
                return true;
            }
        }

        _isCombat = false;
        return false;
    }

    public void StartAttack()
    {
        if (_coroutine == null && Player != null)
        {
            _coroutine = StartCoroutine(Attack(Player));
        }
    }

    public void StopAttack()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Attack(Player player)
    {
        _delayAttack = new WaitForSeconds(_delay);

        while ((transform.position - player.transform.position).sqrMagnitude >= _attackRange)
        {
            player.Health.TakeDamage(_attackDamage);

            yield return _delayAttack;
        }

        _coroutine = null;
    }
}