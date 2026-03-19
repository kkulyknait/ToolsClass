using UnityEngine;
using UnityEngine.InputSystem;


public class TestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _alienPrefabsToSpawn;
    private InputSystem_Actions _input;
    void Awake()
    {
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.Player.SpawnTest.WasPressedThisFrame())
        {
            int randomIndex = Random.Range(0, _alienPrefabsToSpawn.Length);
            Instantiate(_alienPrefabsToSpawn[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
