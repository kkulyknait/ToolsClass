using UnityEngine;
using System.Collections;  // For Coroutines

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _hazardPrefab;
    private bool _checkingWave1 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (_checkingWave1)
        {
            GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            //  if array is enemy, then there's no enemies left 
            if (activeEnemies.Length == 0)
            {
                Debug.Log("Wave 1 Complete!");
                _checkingWave1 = false;  //  Stop checking for wave completion

                //  here's where you would start the next wave
            }
        }
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(3f);  //Delay Logic

        for (int i = 0; i < 5; i++)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), 0, 0);
            Instantiate(_hazardPrefab, transform.position + randomOffset, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);  // Delay between spawns
        }
        _checkingWave1 = true; //Start checking for wave completion
    }

}
