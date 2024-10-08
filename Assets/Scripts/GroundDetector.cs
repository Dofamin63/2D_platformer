using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class GroundDetector : MonoBehaviour
{
    public bool IsGround { get; private set; } = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            IsGround = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            IsGround = false;
        }
    }
}
