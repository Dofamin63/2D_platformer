using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinCount : MonoBehaviour
{
    private TextMeshProUGUI _countView;
    private int _count;

    private void Awake()
    {
        _countView = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Coin.OnCoinCollected += ChangeCount;
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= ChangeCount;
    }

    private void ChangeCount(int takenCoin)
    {
        int sumQuantity = _count + takenCoin;
        _count = sumQuantity;
        _countView.text = $"{_count}";
    }
}