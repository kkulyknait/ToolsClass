using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpriteRenderer _visuals;
    private Collider2D _collider;

    private void Awake()
    {
        _visuals = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.GetComponent<Rigidbody2D>() != null)
        {
            //  Hide Coin
            HideCoin();
            // Schedule Reset
            Invoke("ResetCoin", 3f);
        }
    }
    private void HideCoin()
    {
        _visuals.enabled = false;  //  Invisible
        _collider.enabled = false;  //  Can't touch this!
    }

    private void ResetCoin()
    {
        _visuals.enabled = true;  // Visible
        _collider.enabled = true;  //  Can touch this!
    }
}
