using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Flipper _flipper;
    
    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    public void Move(Vector3 targetPosition)
    {
        _flipper.Rotate(CalculateDirection(targetPosition));
        transform.position = Vector2.MoveTowards(transform.position, targetPosition,
            _speed * Time.deltaTime);
    }

    private float CalculateDirection(Vector3 targetPosition)
    {
        return (targetPosition - transform.position).x;
    }
}
