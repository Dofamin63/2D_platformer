using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private const float _minHealth = 0;
    [SerializeField] private float _currentHealth;

    public event Action Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage > _minHealth)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);

            if (_currentHealth == _minHealth)
            {
                Die();
            }
        }
    }

    public void Heal(float amountHealthRestore)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amountHealthRestore, _minHealth, _maxHealth);
    }

    private void Die()
    {
        // Destroy(gameObject);
    }
}