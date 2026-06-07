using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _nominalCoin;

    public static event Action<int> OnCoinCollected;
    
    public void Collect()
    {
        OnCoinCollected?.Invoke(_nominalCoin);
        Destroy(gameObject);
    }
}