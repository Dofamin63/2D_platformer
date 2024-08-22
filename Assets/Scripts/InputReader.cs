using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    
    public bool IsJump { get; private set; }
    public float Direction { get; private set; }

    private void Update()
    {
        if (Input.GetButton(Horizontal))
        {
            Direction = Input.GetAxis(Horizontal);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            IsJump = true;
        }
    }

    public void DeActivateJumpTrying()
    {
        IsJump = false;
    }
}
