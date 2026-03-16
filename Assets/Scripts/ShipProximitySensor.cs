using UnityEngine;

public class ShipProximitySensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //  Did the player just fly into the sensor?
        if (other.CompareTag("Player"))
        {
            //  look to find the parent manager script
            FleetManager manager = GetComponentInParent<FleetManager>();
            //Null Check
            if (manager != null)
            {
                manager.SoundAlarm();
            }
            
        }
    }
}
