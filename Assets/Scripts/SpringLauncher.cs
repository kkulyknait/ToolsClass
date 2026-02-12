using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpringLauncher : MonoBehaviour
{
    private InputSystem_Actions _input;
    [SerializeField] private float _maxForce = 20f;
    [SerializeField] private float _chargeSpeed = 15f;
    [SerializeField] private float _squishAmount = 0.3f;  //Target Y Scale

    private float _currentCharge = 0f;
    private bool _isPlayerInside = false;
    private Rigidbody2D _playerRb;
    private Vector3 _initialScale;

    private void Awake()
    {
        _input = new InputSystem_Actions();
        _initialScale = transform.localScale;  //Set the initial Scale
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _isPlayerInside = true;
            _playerRb = other.GetComponent<Rigidbody2D>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            _isPlayerInside = false;
            _playerRb = null;
            _currentCharge = 0f;
            transform.localScale = _initialScale;  //Reset our spring
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Game Manager Gating (Added Later)
        //if (GameManager.Instance.IsGameActive == false) return;

        if (!_isPlayerInside) return;
        
        // CHARGING OUR SQUISH
        if(_input.Player.Interact.IsPressed())
        {
            _currentCharge += _chargeSpeed * Time.deltaTime;
            _currentCharge = Mathf.Clamp(_currentCharge, 0, _maxForce);

            float chargePercent = _currentCharge / _maxForce;

            // Go from initial Y position to Squished Y position based on percent
            float newY = Mathf.Lerp(_initialScale.y, _squishAmount, chargePercent);
            transform.localScale = new Vector3(_initialScale.x, newY, _initialScale.z);

        }

        //  LAUNCHING
        if(_input.Player.Interact.WasReleasedThisFrame())
        {
            Fire();
        }


    }
    void Fire()
    {
        if(_playerRb != null)
        {
            _playerRb.AddForce(Vector2.up * _currentCharge, ForceMode2D.Impulse);

            //Snap back to reality
            transform.localScale = _initialScale;  //  Snap back
            _currentCharge = 0f;

        }
    }
}
