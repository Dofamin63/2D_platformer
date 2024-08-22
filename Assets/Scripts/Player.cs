using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(RotationHandler))]
[RequireComponent(typeof(CollisionDetector))]
[RequireComponent(typeof(GroundDetector))]
public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string IsMoved = nameof(IsMoved);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;

    private RotationHandler _rotationHandler;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _isMoving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotationHandler = GetComponent<RotationHandler>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (_inputReader.IsJump)
        {
            Jump();
            _inputReader.DeActivateJumpTrying();
        }
    }

    private void Move()
    {
        float direction = _inputReader.Direction;
        Vector2 directionMove = new Vector2(direction, 0);

        _rotationHandler.Rotate(direction);

        if (Input.GetButton(Horizontal))
        {
            transform.Translate(directionMove * (_moveSpeed * Time.deltaTime));

            if (_groundDetector.IsGround)
                _animator.SetBool(IsMoved, true);
            else
                _animator.SetBool(IsMoved, false);
        }
    }

    private void Jump()
    {
        if (_groundDetector.IsGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}