using UnityEngine;

public class MudZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearDamping = 5f;  //Increase drag

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearDamping = 0f;  //Set drag back to normal

        }

    }
}
