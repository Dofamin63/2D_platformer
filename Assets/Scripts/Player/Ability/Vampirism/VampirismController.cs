using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Vampirism))]
public class VampirismController : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private VampirismView _vampirismView;
    [SerializeField] private float _abilityDuration;
    [SerializeField] private float _cooldownDuration;

    private Vampirism _vampirism;
    private bool _isProcessing;
    private const float StartElapsedTime = 0f;

    private void Awake()
    {
        _vampirism = GetComponent<Vampirism>();
    }

    private void Update()
    {
        _vampirismView.UpdatePosition(transform.position);

        if (!_isProcessing && _inputReader.GetIsVampireAbility())
        {
            StartCoroutine(StartAbilityRoutine());
        }
    }

    private IEnumerator StartAbilityRoutine()
    {
        _isProcessing = true;

        var elapsedTime = StartElapsedTime;
        _vampirismView.StartAbility();

        while (elapsedTime < _abilityDuration)
        {
            _vampirism.Tick(); 
            _vampirismView.TickAbility(elapsedTime, _abilityDuration); 
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _vampirismView.StartCooldown();
        var elapsedCooldown = StartElapsedTime;

        while (elapsedCooldown < _cooldownDuration)
        {
            _vampirismView.TickCooldown(elapsedCooldown, _cooldownDuration);
            elapsedCooldown += Time.deltaTime;
            yield return null;
        }

        _vampirismView.Stop();
        _isProcessing = false;
    }
}