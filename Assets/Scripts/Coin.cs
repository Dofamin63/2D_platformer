using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collected()
    {
        Destroy(gameObject);
    }
}