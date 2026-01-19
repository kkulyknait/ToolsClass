using UnityEngine;
using UnityEngine.InputSystem;

public class Square : MonoBehaviour
{
    private InputSystem_Actions _input;  // Our bridge to the input system
    //private PlayerInputActions _input;

    private Vector2 _moveInput;  //  stores x and y direction
    [SerializeField] private float _moveSpeed = 5f;  // movement speed
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
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Read the movement input from the input system
        _moveInput = _input.Player.Move.ReadValue<Vector2>();

        // Apply Velocity to Rigidbody2D
        _rb.linearVelocity = _moveInput * _moveSpeed; 

        // Apply Movement
       // transform.Translate(_moveInput * _moveSpeed * Time.deltaTime);

    }
}
