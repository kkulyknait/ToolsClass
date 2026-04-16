using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void OpenDoor()
    {
        Debug.Log("Door opened!");
        gameObject.SetActive(false);  
    }
}
