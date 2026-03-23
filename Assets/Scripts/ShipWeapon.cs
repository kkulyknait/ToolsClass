using UnityEngine;
using System.Collections;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private AlienStats _myStats;

    private void Start()
    {
        Debug.Log("I am a " + _myStats.AlienName + " and I am worth " + _myStats.ScoreValue + " points!");
    }

    public void FireLaser()
    {
        Vector3 spawnPos = _firePoint != null ? _firePoint.position : transform.position;
        GameObject newLaser = Instantiate(_laserPrefab, spawnPos, transform.rotation);
        newLaser.GetComponent<LaserProjectile>().AssignAsEnemyLaser();
    }

    public void FireWithDelay(float delayTime)
    {
        StartCoroutine(FireRoutine(delayTime));
    }

    private IEnumerator FireRoutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // Execute the method that contains the correct assignment logic
        FireLaser();
    }
}