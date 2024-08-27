using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyCombat _enemyCombat;
    private Health _health;
    private EnemyMover _enemyMover;

    public Health Health => _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyCombat = GetComponent<EnemyCombat>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        if (_enemyCombat.CanSeePlayer())
        {
            _enemyMover.ChasePlayer(_enemyCombat.Player);

            if (_enemyCombat.IsCombat == false)
            {
                _enemyCombat.StartAttack();
            }
        }
        else
        {
            _enemyMover.Patrol();
            _enemyCombat.StopAttack();
        }
    }
}