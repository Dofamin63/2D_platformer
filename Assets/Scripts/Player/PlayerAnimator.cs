using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsMoved = nameof(IsMoved);
    private const string IsAttacking = nameof(IsAttacking);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartMove()
    {
        _animator.SetBool(IsMoved, true);
    }

    public void StopMove()
    {
        _animator.SetBool(IsMoved, false);
    }

    public void StartAttack()
    {
        _animator.SetBool(IsAttacking, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(IsAttacking, false);
    }
}

