using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform _destination;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If player touches the teleporter, check to see if we should advance
        if (other.CompareTag("Player") && GameManagerMain.Instance != null)
        {
            Debug.Log("Teleporter activated.  Asking Manager for instructions");
            GameManagerMain.Instance.TryAdvanceLevel();
        }

        //Check if this is our player
        //if (other.GetComponent<Rigidbody2D>() != null)
        //{
        //    Debug.Log("Beam me up!");
        //    other.transform.position = _destination.position;
            //other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
       // }
    }
}
