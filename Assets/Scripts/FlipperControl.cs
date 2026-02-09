using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperControl : MonoBehaviour
{
    private HingeJoint2D _joint;
    private JointMotor2D _motor;
    private InputSystem_Actions _input;

    [SerializeField] private float _flipSpeed = 1000f;
    [SerializeField] private float _returnSpeed = -1000f;
    [SerializeField] private bool _isLeftFlipper = true;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint2D>();
        _input = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _input.Enable();
    }
    void OnDisable()
    {
        _input.Disable();
    }

    private void FixedUpdate()
    {
        //  Get motor 
        _motor = _joint.motor;
        // Check input
        bool isPressed = false;
        if(_isLeftFlipper) isPressed = _input.Player.LeftFlipper.IsPressed();
        else isPressed = _input.Player.RightFlipper.IsPressed();
        //  Set Speed
        if (isPressed) _motor.motorSpeed = _flipSpeed;
        else _motor.motorSpeed = _returnSpeed;
        //  Apply back to Joint
        _joint.motor = _motor;
    }
}
