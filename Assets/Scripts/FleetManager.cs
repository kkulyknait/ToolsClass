using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] private float _volleyInterval = 3.0f;  //  Time between volleys
    private float _volleyTimer = 0.0f;
    public void SoundAlarm()
    {
        Debug.Log("Alarm Sounded! Player Detected!");
    }

    private void Update()
    {
        //tick the stopwatch each frame
        _volleyTimer += Time.deltaTime;

        //  Is it time to shoot?
        if (_volleyTimer >= _volleyInterval)
        {
            CommandVolleyFire();
            _volleyTimer = 0.0f;  // reset timer
        }
    }

    private void CommandVolleyFire()
    {
        //  Loop through each child of the fleet manager, grab the ShipWeapon and SHOOT!

        ShipWeapon[] allShips = GetComponentsInChildren<ShipWeapon>();
        
        // Loop through array
        foreach(ShipWeapon ship in allShips)
        {
            ship.FireLaser();
        }
    }
}
