using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJump;
    private bool _isVampireAbility;
    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _isVampireAbility = true;
        }
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    public bool GetIsVampireAbility() => GetBoolAsTrigger(ref _isVampireAbility);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool current = value;
        value = false;
        return current;
    }
}