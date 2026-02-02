using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 15f;
    private SpriteRenderer _renderer;
    private Color _originalColor;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _originalColor = _renderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  Check to see if the collision is with the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            //  Add a bounce if there's a rigidbody on Player
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.up * _bounceForce, ForceMode2D.Impulse);
            }
            //  Visual Feedback
            _renderer.color = Color.green;
            Invoke("ResetColor", 0.5f);

        }
    }
    private void ResetColor()
    {
        _renderer.color = _originalColor;
    }
}
