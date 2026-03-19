using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] private float _volleyInterval = 3.0f;  //  Time between volleys
    [SerializeField] private int _maxVolleys = 3;  /// how many volleys
    
    private float _volleyTimer = 0.0f;
    private int _volleysFired = 0;  //  Our burst counter
    private bool _isAlarmActive = false;


    public void SoundAlarm()
    {
        if (!_isAlarmActive)
        {
            Debug.Log("Alarm Sounded! Player Detected!  Initaing staggered burst!");
            _isAlarmActive = true;
            _volleysFired = 0;  //  Reset the counter for a new burst
            _volleyTimer = _volleyInterval;  //  Set to interval so they fire the first wave immediately
        }

    }

    private void Update()
    {
        if (_isAlarmActive)
        {
            //tick the stopwatch each frame
            _volleyTimer += Time.deltaTime;

            //  Is it time to shoot?
            if (_volleyTimer >= _volleyInterval)
            {
                CommandVolleyFire();
                _volleyTimer = 0.0f;  // reset timer
                _volleysFired++;  //  Add 1 to our volley counter
                if (_volleysFired >= _maxVolleys)
                {
                    Debug.Log("Burst complete.  Returning to standby.");
                    _isAlarmActive = false;
                }

            }
        }
    }

    private void CommandVolleyFire()
    {
        //  Loop through each child of the fleet manager, grab the ShipWeapon and SHOOT!

        ShipWeapon[] allShips = GetComponentsInChildren<ShipWeapon>();
        
        // Loop through array
        foreach(ShipWeapon ship in allShips)
        {
            //ship.FireLaser();
            //  Give each ship a random delay
            float randomDelay = Random.Range(0f, 1.5f);
            //  Call our new coroutine method
            ship.FireWithDelay(randomDelay);
        }
    }
}
