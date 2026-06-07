using UnityEngine;
using UnityEngine.UI;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private Slider _timeBar;
    [SerializeField] private SpriteRenderer _radiusRender;
    [SerializeField] private Vector3 _barOffset;

    private const float MinBarValue = 0f;
    private const float MaxBarValue = 1f;

    public void UpdatePosition(Vector3 ownerPosition)
    {
        _timeBar.transform.position = ownerPosition + _barOffset;
    }

    public void StartAbility()
    {
        _timeBar.gameObject.SetActive(true);
        _radiusRender.gameObject.SetActive(true);
        _timeBar.value = MaxBarValue;
    }

    public void TickAbility(float elapsedTime, float duration)
    {
        _timeBar.value = MaxBarValue - (elapsedTime / duration);
    }

    public void StartCooldown()
    {
        _radiusRender.gameObject.SetActive(false);
        _timeBar.value = MinBarValue;
    }

    public void TickCooldown(float elapsedTime, float duration)
    {
        _timeBar.value = elapsedTime / duration;
    }

    public void Stop()
    {
        _timeBar.gameObject.SetActive(false);
    }
}