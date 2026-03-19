using UnityEngine;
using System.Collections;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;  //  Assign the laser prefab in the inspector
    [SerializeField] private Transform _firePoint;  //  Assign the fire point

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
