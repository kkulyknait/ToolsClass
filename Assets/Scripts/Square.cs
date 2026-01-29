using UnityEngine;
using UnityEngine.InputSystem;

public class Square : MonoBehaviour
{
    private InputSystem_Actions _input;  // Our bridge to the input system
    //private PlayerInputActions _input;

    private Vector2 _moveInput;  //  stores x and y direction
    [SerializeField] private float _moveSpeed = 5f;  // movement speed
    [SerializeField] private float _jumpStrength = 5f;
    private Rigidbody2D _rb;  // reference to Rigidbody2D component

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
    }
    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Read the movement input from the input system
        _moveInput = _input.Player.Move.ReadValue<Vector2>();

        // Apply Velocity to Rigidbody2D
        //_rb.linearVelocity = _moveInput * _moveSpeed; 
        _rb.linearVelocity = new Vector2(_moveInput.x * _moveSpeed, _rb.linearVelocity.y);
        

        // Apply Movement
       // transform.Translate(_moveInput * _moveSpeed * Time.deltaTime);

    }
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
        Debug.Log("Hey, I'm jumping here.");
    }
}
