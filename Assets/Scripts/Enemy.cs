using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyCombat _enemyCombat;
    private Health _health;
    private EnemyMover _enemyMover;
    private PlayerDetector _playerDetector;

    public Health Health => _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyCombat = GetComponent<EnemyCombat>();
        _enemyMover = GetComponent<EnemyMover>();
        _playerDetector = GetComponent<PlayerDetector>();
    }

    private void Update()
    {
        if (_playerDetector.IsSeePlayer())
        {
            _enemyMover.ChasePlayer(_playerDetector.Player);
            _enemyCombat.TryAttack(_playerDetector.Player);
        }
        
        else
        {
            _enemyMover.Patrol();
        }
    }
}