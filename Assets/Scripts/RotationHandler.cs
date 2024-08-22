using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    public void Rotate(float direction)
    {
        if ((direction > 0 && transform.localScale.x < 0) || (direction < 0 && transform.localScale.x > 0))
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
