using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private int _chaseRange;
    [SerializeField] private float _stopDistance;
    
    private EnemyMover _enemyMover;
    
    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }
    
    public void ChasePlayer(Player player)
    {
        float distanceSquared = (transform.position - player.transform.position).sqrMagnitude;
        float chaseRangeSquared = _chaseRange * _chaseRange;
        float stopDistanceSquared = _stopDistance * _stopDistance;
    
        if (distanceSquared < chaseRangeSquared && distanceSquared > stopDistanceSquared)
        {
            _enemyMover.Move(player.transform.position);
        }
    }
}