using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private Vector3 _coinSpawnPoint;
    private float _timer = 2.0f;

    [SerializeField] private GroundSpawner _groundSpawner;
    [SerializeField] private GameObject CoinPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        _timer -= Time.deltaTime;

        int spawnTime = Random.Range(1, 3);

        if (_timer < 0)
        {
            _timer += spawnTime;
            Instantiate(CoinPrefab, RandomPositionGenerator(), CoinPrefab.transform.rotation);
        }
    }

    private Vector3 RandomPositionGenerator()
    {
        int lane = Random.Range(0, 2);
        
        if (lane == 0) _coinSpawnPoint.z = -3;
        else if (lane == 1) _coinSpawnPoint.z = 0;
        else _coinSpawnPoint.z = 3;
        
        _coinSpawnPoint.x =
            Random.Range(_groundSpawner._nextPointToSpawn.x + 2, _groundSpawner._nextPointToSpawn.x + 12);

        _coinSpawnPoint.y = 2;
        return _coinSpawnPoint;
    }
}
