using UnityEngine;

public class RotatingBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;  // Speed of the bullet
    [SerializeField] private float _spinSpeed = 360f;  // Degrees per second

    //  Use this for direction
    private float _direction = 1f;  //  1 for right, -1 for left

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f); //  Destroy bullet after 3 seconds 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _direction * _speed * Time.deltaTime, 
            Space.World);
        transform.Rotate(0, 0, _spinSpeed * Time.deltaTime);  // Rotate projectile
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //  Destroy both enemy and bullet if hit
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    public void SetDirection(float direction)
    {
        _direction = direction;

    }
}
