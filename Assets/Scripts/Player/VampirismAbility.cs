using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Slider _timeBar;
    [SerializeField] private SpriteRenderer _radiusRender;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Vector3 _barOffset;
    [SerializeField] private float _abilityDuration;
    [SerializeField] private float _cooldownDuration;
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _radius;

    private Health _health;
    private bool _isActive;
    private bool _isOnCooldown;
    private float _timer;
    private float _startTime = 0f;
    private float _endTime = 1f;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        _timeBar.transform.position = transform.position + _barOffset;

        if (_isActive == false && _isOnCooldown == false && _inputReader.GetIsVampireAbility())
        {
            StartCoroutine(AbilityRoutine());
        }

        UpdateBar();
    }

    private IEnumerator AbilityRoutine()
    {
        _isActive = true;
        _timer = _abilityDuration;
        _timeBar.gameObject.SetActive(true);
        _radiusRender.gameObject.SetActive(true);

        while (_timer > _startTime)
        {
            _timer -= Time.deltaTime;
            ApplyVampireEffect();
            yield return null;
        }
        
        EndAbility();
    }

    private void EndAbility()
    {
        _isActive = false;
        _isOnCooldown = true;
        _timer = _cooldownDuration;
        _radiusRender.gameObject.SetActive(false);
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        while (_timer > _startTime)
        {
            _timer -= Time.deltaTime;
            yield return null;
        }

        _isOnCooldown = false;
        _timeBar.gameObject.SetActive(false);
    }

    private void ApplyVampireEffect()
    {
        Enemy nearest = FindNearestEnemy();
        if (nearest == null) return;

        float damage = _damagePerSecond * Time.deltaTime;
        nearest.Health.TakeDamage(damage);
        _health.Heal(damage);
    }

    private Enemy FindNearestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyMask);
        Enemy nearest = null;
        float minDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemy;
                }
            }
        }

        return nearest;
    }

    private void UpdateBar()
    {
        if (_isActive)
        {
            _timeBar.value = _timer / _abilityDuration;
        }
        else if (_isOnCooldown)
        {
            _timeBar.value = _endTime - (_timer / _cooldownDuration);
        }
        else
        {
            _timeBar.value = _startTime;
        }
    }
}