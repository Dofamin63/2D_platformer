using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private int _chaseRange;
    
    private Flipper _flipper;
    private int _currentPosition;
    
    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    public void ChasePlayer(Player player)
    {
        if ((transform.position - player.transform.position).sqrMagnitude < _chaseRange)
        {
            _flipper.Rotate(CalculateDirection(player.transform));
            Move(player.transform.position);
        }
    }

    public void Patrol()
    {
        if (transform.position == _waypoints[_currentPosition].position)
        {
            _currentPosition = ++_currentPosition % _waypoints.Count;
        }
    
        _flipper.Rotate(CalculateDirection(_waypoints[_currentPosition]));
        Move(_waypoints[_currentPosition].position);
    }

    private void Move(Vector2 position)
    {
        transform.position = Vector2.MoveTowards(transform.position, position,
            _speed * Time.deltaTime);
    }

    private float CalculateDirection(Transform to)
    {
        Vector2 direction = to.position - transform.position;
        return direction.x;
    }
}
