using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    private int _currentPosition;
    private EnemyMover _enemyMover;
    
    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }
    
    public void Patrol()
    {
        if (transform.position == _waypoints[_currentPosition].position)
        {
            _currentPosition = ++_currentPosition % _waypoints.Count;
        }
    
        _enemyMover.Move(_waypoints[_currentPosition].position);
    }
}