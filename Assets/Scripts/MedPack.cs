using UnityEngine;

public class MedPac : MonoBehaviour
{
    [SerializeField] private float _amountHealth;

    public float AmountHealth => _amountHealth;
    
    public void Collect()
    {
        Destroy(gameObject);
    }
}
