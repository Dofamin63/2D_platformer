using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collected();
        }
        if (collision.TryGetComponent(out MedPac medPac))
        {
            medPac.Collected();
        }
    }
}
