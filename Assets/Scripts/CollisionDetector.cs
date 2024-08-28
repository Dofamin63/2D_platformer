using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
        }
        
        if (collision.TryGetComponent(out MedPac medPac))
        {
            _health.Heal(medPac.AmountHealth);
            medPac.Collect();
        }
    }
}
