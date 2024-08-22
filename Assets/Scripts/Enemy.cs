using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _waypoints;

    private int _currentPosition;
    private Flipper _rotationHandler;

    private void Awake()
    {
        _rotationHandler = GetComponent<Flipper>();
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentPosition].position)
        {
            _currentPosition = ++_currentPosition % _waypoints.Count;
        }
        
        Vector2 direction = _waypoints[_currentPosition].position - transform.position;
        _rotationHandler.Rotate(direction.x);
        
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentPosition].position,
            _speed * Time.deltaTime);
    }
}
