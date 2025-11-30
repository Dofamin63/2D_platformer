using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float animationTime;
    private const string IsAttack = nameof(IsAttack);
    private EnemyCombat _enemyCombat;
    private Health _health;
    private EnemyChase _enemyChase;
    private EnemyPatrol _enemyPatrol;
    private PlayerDetector _playerDetector;
    private Animator _animator;

    public Health Health => _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyCombat = GetComponent<EnemyCombat>();
        _enemyChase = GetComponent<EnemyChase>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _playerDetector = GetComponent<PlayerDetector>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerDetector.IsSeePlayer())
        {
            _enemyChase.ChasePlayer(_playerDetector.Player);
            _enemyCombat.TryAttack(_playerDetector.Player);
        }

        else
        {
            _enemyPatrol.Patrol();
        }
    }
    
    private void OnEnable()
    {
        _enemyCombat.OnAttack += PlayAttack;
    }
    
    private void OnDisable()
    {
        _enemyCombat.OnAttack -= PlayAttack;
    }
    
    private void PlayAttack()
    {
        _animator.SetBool(IsAttack, true);
        StartCoroutine(ResetAttackAnimation());
    }

    private IEnumerator ResetAttackAnimation()
    {
        yield return new WaitForSeconds(animationTime);
        _animator.SetBool(IsAttack, false);
    }
}