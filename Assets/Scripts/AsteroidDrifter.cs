using System.Runtime.CompilerServices;
using UnityEngine;

public class AsteroidDrifter : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private Vector2 _direction = new Vector2(1f, 0f);  
    [SerializeField] private float _speed = 2f;  //Speed of drifting
    [SerializeField] private float _spinSpeed = 45f;  // 

    [SerializeField] private float _leftBoundary = -10f;
    [SerializeField] private float _rightBoundary = 10f;

    private void Update()
    {
        MoveAsteroid();
        SpinAsteroid();
        CheckBoundaries();
    }

    private void MoveAsteroid()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
    private void SpinAsteroid()
    {
        transform.Rotate(0f, 0f, _spinSpeed * Time.deltaTime);
    }

    private void CheckBoundaries()
    {
        if(transform.position.x > _rightBoundary)
        {
            transform.position = new Vector3(_leftBoundary, transform.position.y, transform.position.z);
        }
    }

}

