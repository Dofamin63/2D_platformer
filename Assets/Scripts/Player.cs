using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string IsMoved = nameof(IsMoved);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundDetector _groundDetector;
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool _isMoving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);
        Vector2 directionMove = new Vector2(direction, 0);
        
        if (direction > 0)
        {
            _spriteRenderer.flipX = false; 
        }
        
        else if (direction < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (Input.GetButton(Horizontal))
        {
            transform.Translate(directionMove * (_moveSpeed * Time.deltaTime));
            _animator.SetBool(IsMoved, true);
        }
        else
        {
            _animator.SetBool(IsMoved, false);
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundDetector.IsGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}