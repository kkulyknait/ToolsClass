using UnityEngine;
using UnityEngine.InputSystem;

public class Square : MonoBehaviour
{
    private InputSystem_Actions _input;  // Our bridge to the input system



    private Vector2 _moveInput;  //  stores x and y direction
    [SerializeField] private float _moveSpeed = 5f;  // movement speed
    [SerializeField] private float _jumpStrength = 5f;
    private Rigidbody2D _rb;  // reference to Rigidbody2D component


    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;  //  Drag firing location here


    private void Awake()
    {
        _input = new InputSystem_Actions();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input.Player.Jump.performed += ctx => Jump();
        // Make sure Input Action name for attack is correct here
        _input.Player.Attack.performed += ctx => Fire();
    }
    private void Update()
    {
        _moveInput = _input.Player.Move.ReadValue<Vector2>();
        // Flipping Logic
        //  If X is gretern then 0, walking right, otherwise walking left
        if (_moveInput.x > 0)
        {
            //  Set scate to normal facing right
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if (_moveInput.x < 0)
        {
            //  This flips the sprite 
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
        }
    }

    void FixedUpdate()
    {
        // Read the movement input from the input system
        //_moveInput = _input.Player.Move.ReadValue<Vector2>();

        float targetVelocityX = _moveInput.x * _moveSpeed;
        float smoothVelocityX = Mathf.Lerp(_rb.linearVelocity.x, targetVelocityX,
            Time.fixedDeltaTime * 10f);  // Adjust the smooth factor

        // Apply Velocity to Rigidbody2D
        
        _rb.linearVelocity = new Vector2(smoothVelocityX, _rb.linearVelocity.y);
      

    }
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
        
    }

    private void Fire()
    {
        // Null CHECK!
        if (_bulletPrefab != null && _firePoint != null)
        {
            // Create a new bullet  
            GameObject newBullet = Instantiate(_bulletPrefab, _firePoint.position,
                Quaternion.identity);
            // Check which way we are facing 
            float facingDir = Mathf.Sign(transform.localScale.x);

            // Set bullet direction
            RotatingBullet bulletScript = newBullet.GetComponent<RotatingBullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(facingDir);
            }
        }
    }
}
