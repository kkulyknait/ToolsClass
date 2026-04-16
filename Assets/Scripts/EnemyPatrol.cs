using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 2f;
    private Transform _currentTarget;

    private void Start() => _currentTarget = _pointA;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget.position,
            _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _currentTarget.position) < 0.1f)
        {
            _currentTarget = (_currentTarget == _pointA) ? _pointB : _pointA;
        }
    }

}
