using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class GroundDetector : MonoBehaviour
{
    private int _groundCollisionsCount;
    private int _zeroValue = 0;
    public bool IsGround { get; private set; } = true;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            _groundCollisionsCount++;
            IsGround = true;
            UpdateGroundedState();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            _groundCollisionsCount--;
            IsGround = false;
            UpdateGroundedState();
        }
    }
    
    private void UpdateGroundedState()
    {
        IsGround = _groundCollisionsCount > _zeroValue;
    }
}
