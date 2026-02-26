using UnityEngine;

public class ReactiveBumper : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 10f;
    [SerializeField] private Color _hitColor = Color.cyan;

    private SpriteRenderer _renderer;
    private Color _originalColor;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _originalColor = _renderer.color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.CompareTag("Player"))
       // {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                //  Get our exact angle of impact
                Vector2 bounceDirection = collision.GetContact(0).normal;
                //  Apply bounce force in the direction opposite to the collision normal
                playerRb.AddForce(bounceDirection * _bounceForce, ForceMode2D.Impulse);
            }
            // Visual Feedback
            _renderer.color = _hitColor;
            Invoke("ResetColor", 0.2f);
      //  }
    }
    private void ResetColor()
    {
        _renderer.color = _originalColor;
    }
}
