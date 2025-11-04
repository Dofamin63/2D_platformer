using UnityEngine;

public abstract class HealthBarBase : MonoBehaviour
{
    [SerializeField] protected Health _health;
    private Vector3 _offset = new(0f, 1f, 0f);

    private void Update()
    {
        transform.position = _health.transform.position + _offset;
    }

    private void OnEnable()
    {
        _health.OnHealthChanged += ChangeHealth;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= ChangeHealth;
        _health.Died -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void ChangeHealth(float currentHealth, float maxHealth);
}