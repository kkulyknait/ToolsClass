using UnityEngine;

public class NebularDetector : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
            Debug.Log("Warning: Entering Nebula. Sensors scrambled.");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Note: This prints every single frame while they are inside! 
        if (other.CompareTag("Hazard"))
            Debug.Log("Taking corrosive damage...");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
            Debug.Log("Exited Nebula. Systems restoring.");
    }
}

