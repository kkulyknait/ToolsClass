using Unity.VisualScripting;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private DoorController _targetDoor;
    [SerializeField] private ItemData _requiredKey;  //  Which key opens door

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _targetDoor != null)
        {
            if (GameManagerMain.Instance.HasItem(_requiredKey))
            {
                _targetDoor.OpenDoor();
            }
            else
            {
                Debug.Log("Locked!  You need the " + _requiredKey.ItemName);
            }

        }
    }
}
