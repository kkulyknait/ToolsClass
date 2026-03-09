using UnityEngine;
using UnityEngine.InputSystem;

public class MinerController : MonoBehaviour
{
    private InputSystem_Actions _input;
    private Vector2 _moveInput;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _spinSpeed = 180f;
    [SerializeField] private GameObject _laserPrefab;  //  Drag and drop our laser prefab here in the Inspector
    [SerializeField] private Transform _firingPoint;  //  Drag our FirePoint here!  

    [SerializeField] private float _chargeTime = 1.0f;  //  Time to fully charge the shot
    private float _currentChargeTime = 0f;  //  Our stopwatch
    private bool _isCharging = false;  //  Are we currently charging?

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
        ////  Read Inputs
        //_moveInput = _input.Player.Move.ReadValue<Vector2>();

        ////  Translate
        //transform.Translate(_moveInput * _moveSpeed * Time.deltaTime, Space.World);

        ////  Rotate
        //if (_input.Player.SpinLeft.IsPressed())
        //{
        //    transform.Rotate(0, 0, _spinSpeed * Time.deltaTime);
        //}
        //if (_input.Player.SpinRight.IsPressed())
        //{
        //    transform.Rotate(0, 0, -_spinSpeed * Time.deltaTime);
        //}

        ///  Asteroids  Style Controls
        ///  
        Vector2 moveInput = _input.Player.Move.ReadValue<Vector2>();
        ////  Spin using the X input A/D Keys
        transform.Rotate(0, 0, -moveInput.x * _spinSpeed * Time.deltaTime);
        transform.Translate(new Vector2(0, moveInput.y) * _moveSpeed 
            * Time.deltaTime, Space.Self);

        //// Space Invaders Style Controls
        //Vector2 moveInput = _input.Player.Move.ReadValue<Vector2>();
        //// Move only the X, Ignore the Y
        //transform.Translate(new Vector2(moveInput.x, 0) *_moveSpeed
        //    * Time.deltaTime, Space.World);

        //float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);  // Adjsut to 8f to the screen size
        //transform.position = new Vector3 (clampedX, -2f, transform.position.z);  // Adjust Y to the bottom of the screen

        //  WEAPON CONTROLS
        //  Standard Shot
        if (_input.Player.Attack.WasPressedThisFrame())
        {
            _isCharging = true;  //  Start charging
            _currentChargeTime = 0f;  //  Reset the stopwatch
        }
        if (_isCharging && _input.Player.Attack.IsPressed())
        {
            _currentChargeTime += Time.deltaTime;  //  Keep charging
            //  Optional....we could add some visual feedback here
        }
        if(_input.Player.Attack.WasReleasedThisFrame())
        {
            _isCharging = false;  //  Stop charging
            if (_currentChargeTime >= _chargeTime)
            {
                //  ALT FIRE!!!!
                GameObject giantLaser = Instantiate(_laserPrefab, _firingPoint.position, _firingPoint.rotation);
                giantLaser.transform.localScale *= 4f;  //  Make twice as big!

            }
            else
            {
                Instantiate(_laserPrefab, _firingPoint.position, _firingPoint.rotation);
            }
        }

    }

}


