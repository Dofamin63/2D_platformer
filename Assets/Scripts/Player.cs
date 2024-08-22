using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(Flipper))]
[RequireComponent(typeof(CollisionDetector), typeof(GroundDetector))]
public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string IsMoved = nameof(IsMoved);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;

    private Flipper _flipper;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _isMoving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            Jump();
        }
    }

    private void Move()
    {
        float direction = _inputReader.Direction;
        Vector2 directionMove = new Vector2(direction, 0);

        _flipper.Rotate(direction);

        if (Input.GetButton(Horizontal))
        {
            transform.Translate(directionMove * (_moveSpeed * Time.deltaTime));

            if (_groundDetector.IsGround)
                _animator.SetBool(IsMoved, true);
        }
        else
        {
            _animator.SetBool(IsMoved, false);
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}