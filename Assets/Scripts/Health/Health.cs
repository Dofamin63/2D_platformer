using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float ZeroValue = 0;

    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public event Action<float, float> OnHealthChanged;
    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        NotifyHealthChanged();
    }

    public void TakeDamage(float damage)
    {
        if (damage < ZeroValue)
            throw new ArgumentException("Урон не может быть отрицательным.", nameof(damage));

        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        NotifyHealthChanged();

        if (_currentHealth == _minHealth)
        {
            Die();
        }
    }

    public void Heal(float amountHealthRestore)
    {
        if (amountHealthRestore < ZeroValue)
            throw new ArgumentException("Лечение не может быть отрицательным.", nameof(amountHealthRestore));

        _currentHealth = Mathf.Clamp(_currentHealth + amountHealthRestore, _minHealth, _maxHealth);
        NotifyHealthChanged();
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }

    private void NotifyHealthChanged()
    {
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}