using UnityEngine;
using System.Collections;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 3f;

    private void Start()
    {
        //  A Coroutine is a background timer
        StartCoroutine(CleanupRoutine());
    }
    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);
    }
    private IEnumerator CleanupRoutine()
    {
        //  Wait for the lifetime duration
        yield return new WaitForSeconds(_lifetime);
        // Times Up!  Destroy!
        Destroy(gameObject);
    }
        //Hit Detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        //What did we hit?
        if ( other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy!");
            Destroy(other.gameObject);  //  Destroy the enemy
            Destroy(gameObject);  // Destroy the laser
        }
    }


}
