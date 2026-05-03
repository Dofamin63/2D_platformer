using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Flipper))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerCombat _playerCombat;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private float _attackDuration = 0.3f;

    private Flipper _flipper;
    private Health _health;
    private float _previousDirection;
    
    public Health Health => _health;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _health = GetComponent<Health>();
        _playerMover = GetComponent<PlayerMover>();
        _playerCombat = GetComponent<PlayerCombat>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }
    
    private void FixedUpdate()
    {
        float currentDirection = _inputReader.Direction;
        
        if (currentDirection != 0)
        {
            if (_previousDirection == 0)
            {
                _playerAnimator?.StartMove();
            }
            
            _flipper.Rotate(currentDirection);
            _playerMover.Move(currentDirection);
        }
        else
        {
            if (_previousDirection != 0)
            {
                _playerAnimator?.StopMove();
            }
        }
        
        _previousDirection = currentDirection;

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _playerMover.Jump();
        }
    }

    private void OnEnable()
    {
        _playerCombat.OnAttack += OnAttack;
    }

    private void OnDisable()
    {
        _playerCombat.OnAttack -= OnAttack;
    }

    private void OnAttack()
    {
        _playerAnimator?.StartAttack();
        StartCoroutine(StopAttackAfterDelay());
    }

    private IEnumerator StopAttackAfterDelay()
    {
        yield return new WaitForSeconds(_attackDuration);
        _playerAnimator?.StopAttack();
    }
}