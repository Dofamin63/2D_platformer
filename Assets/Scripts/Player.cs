using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundDetector _groundDetector;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
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
        
        transform.Translate(directionMove * (_moveSpeed * Time.deltaTime));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundDetector.IsGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}