using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _waypoints;

    private SpriteRenderer _spriteRenderer;
    private int _currentPosition;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentPosition].position)
        {
            _currentPosition = ++_currentPosition % _waypoints.Count;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentPosition].position,
            _speed * Time.deltaTime);
    }
}
