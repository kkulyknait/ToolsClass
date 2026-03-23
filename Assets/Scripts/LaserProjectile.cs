using UnityEngine;
using System.Collections;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 3f;
    [SerializeField] private bool _isEnemyLaser = false;  //  Is this laser from an enemy?

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

    public void AssignAsEnemyLaser()
    {
        _isEnemyLaser = true;
    }
    //Hit Detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isEnemyLaser)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player Hit!");
                Destroy(other.gameObject);  //  Destroy the player
                Destroy(gameObject);  // Destroy the laser
            }
            //  Did we hit an asteroid?
            if (other.CompareTag("Destructible"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);  // Destroy the laser
            }
        }
        else { 
                //What did we hit?
                if (other.CompareTag("Enemy"))
                {
                    Debug.Log("Hit Enemy!");
                    Destroy(other.gameObject);  //  Destroy the enemy
                    Destroy(gameObject);  // Destroy the laser
                }

                //  Did we hit an asteroid?
                if (other.CompareTag("Destructible"))
                {
                    Destroy(other.gameObject);
                    Destroy(gameObject);  // Destroy the laser
                }
             }
    }


}
