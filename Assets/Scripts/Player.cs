using UnityEngine;

[RequireComponent(typeof(Player), typeof(Health), typeof(Flipper))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string IsMoved = nameof(IsMoved);

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerMover _playerMover;

    private Flipper _flipper;
    private Animator _animator;
    private Health _health;
    
    public Health Health => _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _flipper = GetComponent<Flipper>();
        _health = GetComponent<Health>();
        _playerMover = GetComponent<PlayerMover>();
    }
    
    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _animator.SetBool(IsMoved, true);
            _flipper.Rotate(_inputReader.Direction);
            _playerMover.Move(_inputReader.Direction);
        }
        else
        {
            _animator.SetBool(IsMoved, false);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _playerMover.Jump();
    }
}