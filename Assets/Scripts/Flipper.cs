using UnityEngine;

public class Flipper : MonoBehaviour
{
    private const float _scaleY = 1;
    private float _currentScale;

    private void Awake()
    {
        _currentScale = transform.localScale.x;
    }

    public void Rotate(float direction)
    {
        if ((direction > 0 && _currentScale < 0) || (direction < 0 && _currentScale > 0))
        {
            transform.localScale = new Vector2(-_currentScale, _scaleY);
            _currentScale = -_currentScale;
        }
    }
}
