using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothBar : HealthBarBase
{
    [SerializeField] private float _animationDuration = 1f;

    private Slider _healthSlider;
    private Coroutine _smoothCoroutine;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    protected override void ChangeHealth(float currentHealth, float maxHealth)
    {
        float targetHealth = currentHealth / maxHealth;
        
        if (_smoothCoroutine != null)
        {
            StopCoroutine(_smoothCoroutine);
        }
        _smoothCoroutine = StartCoroutine(SmoothUpdateHealth(targetHealth));
    }

    private IEnumerator SmoothUpdateHealth(float targetHealth)
    {
        float startValue = _healthSlider.value;
        float elapsedTime = 0f;

        while (elapsedTime < _animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progressTime = elapsedTime / _animationDuration;
            
            _healthSlider.value = Mathf.Lerp(startValue, targetHealth, progressTime);
            yield return null;
        }
    }
}
