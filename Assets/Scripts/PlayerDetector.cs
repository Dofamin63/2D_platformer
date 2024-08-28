using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private float _detectionZone;

    public Player Player { get; private set; }

    public bool IsSeePlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _detectionZone, _playerMask);

        foreach (Collider2D hit in colliders)
        {
            if (hit.TryGetComponent(out Player player))
            {
                Player = player;
                return true;
            }
        }
        
        return false;
    }
}
