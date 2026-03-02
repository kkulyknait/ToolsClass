using UnityEngine;
using UnityEngine.InputSystem;

public class MinerController : MonoBehaviour
{
    private InputSystem_Actions _input;
    private Vector2 _moveInput;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _spinSpeed = 180f;

    private void Awake()
    {
        _input = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        //  Read Inputs
        _moveInput = _input.Player.Move.ReadValue<Vector2>();

        //  Translate
        transform.Translate(_moveInput * _moveSpeed * Time.deltaTime, Space.World);

        //  Rotate
        if (_input.Player.SpinLeft.IsPressed())
        {
            transform.Rotate(0, 0, _spinSpeed * Time.deltaTime);
        }
        if (_input.Player.SpinRight.IsPressed())
        {
            transform.Rotate(0, 0, -_spinSpeed * Time.deltaTime);
        }
    }

}


