using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJump;
    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }
    }
    
    public bool GetIsJump() => GetBoolAsTrigger(_isJump);

    private bool GetBoolAsTrigger(bool isJump)
    {
        _isJump = false;
        return isJump;
    }
}