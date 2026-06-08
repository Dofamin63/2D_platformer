using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
    public Transform transform { get; }
}