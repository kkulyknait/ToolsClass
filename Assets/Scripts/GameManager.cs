using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  /// This is our script access point
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawnPoint;

    ///  Checkpoint to see if game is active before allowing inputs and player respawn 
    public bool IsGameActive { get; private set; } = true;

    private void Awake()
    {
        Instance = this;  // / Set the instance to this script
    }
    //called by the death zone when the player dies
    public void OnPlayerDied()
    {
        IsGameActive = false;  // Set the game to inactive to prevent player input during respawn

        _player.gameObject.SetActive(false);  // Hide the player during respawn
        _player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;  // Stop player physics
        Invoke("RespawnPlayer", 2f);  ///  Wait 2 seconds before respawning the player
    }

    private void RespawnPlayer()
    {
        _player.position = _spawnPoint.position;  //  move to spawn
        _player.gameObject.SetActive(true);  //  Toggle player back on
        IsGameActive = true;  //  OPEN THE GATE  
    }


}
