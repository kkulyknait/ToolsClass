using UnityEngine;
using System.Collections;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;  //  Assign the laser prefab in the inspector
    [SerializeField] private Transform _firePoint;  //  Assign the fire point
    [SerializeField] private AlienStats _myStats;

    private void Start()
    {
        //  Read the ship data dynamically
        Debug.Log("I am a " + _myStats.AlienName + " and I am worth " + _myStats.ScoreValue
            + " points!");

        // _speed = _myStats.MovementSpeed;
    }

    public void FireLaser()
    {
        Vector3 spawnPos = _firePoint != null ? _firePoint.position : transform.position; //  Use fire point position if assigned, otherwise use ship's position
        Instantiate(_laserPrefab, spawnPos, transform.rotation); //  Spawn the laser at the fire point's position and rotation
    }
    public void FireWithDelay(float delayTime)
    {
        StartCoroutine(FireRoutine(delayTime));
    }

    private IEnumerator FireRoutine (float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ///  Time's up!  Fire the LASERS!
        Vector3 spawnPos = _firePoint != null ? _firePoint.position : transform.position;
        Instantiate(_laserPrefab, spawnPos, transform.rotation);
    }
}
