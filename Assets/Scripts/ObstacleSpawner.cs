using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private Vector3 _wagonSpawnPoint;
    private float _timer = 3.0f;

    [SerializeField] private GroundSpawner _groundSpawner;
    [SerializeField] private GameObject WagonPrefab;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        SpawnWagon();
    }
    
    private void SpawnWagon()
    {
        _timer -= Time.deltaTime;

        int spawnTime = Random.Range(1, 3);

        if (_timer < 0)
        {
            _timer += spawnTime;
            Instantiate(WagonPrefab, RandomPositionGenerator(), WagonPrefab.transform.rotation);
        }
    }

    private Vector3 RandomPositionGenerator()
    {
        int lane = Random.Range(-1, 2);
        
        if (lane == 0) _wagonSpawnPoint.z = -3;
        else if (lane == 1) _wagonSpawnPoint.z = 0;
        else if(lane == 2) _wagonSpawnPoint.z = 3;
        
        _wagonSpawnPoint.x =
            Random.Range(_groundSpawner._nextPointToSpawn.x + - 10, _groundSpawner._nextPointToSpawn.x + 12);

        _wagonSpawnPoint.y = 0;
        return _wagonSpawnPoint;
    }
}
