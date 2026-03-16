using UnityEngine;

public class FleetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _columns = 5;
    [SerializeField] private float _spacing = 2.0f;  //  Distance between enemies

    private void Start()
    {
        SpawnGrid();
    }

    private void SpawnGrid()
    {
        Quaternion faceDown = Quaternion.Euler(0, 0, 180);  //  Rotate the enemy to face downwards

        //  Loop through rows (Y Axis)
        for (int y = 0; y < _rows; y++)
        {
            // Loop through columns (X Axis)
            for (int x = 0; x < _columns; x++)
            {
                //  Calculate where theis ship should be spawned in the grid
                Vector2 spawnPos = new Vector2(transform.position.x + (x * _spacing), transform.position.y - (y * _spacing));
                // Spawn the enemy ship at the calculated position
                GameObject newShip = Instantiate(_enemyPrefab, spawnPos, faceDown);

                //  Make this ship a child of the FleetSpawner
                newShip.transform.SetParent(this.transform);

            }
        }
    }

}

