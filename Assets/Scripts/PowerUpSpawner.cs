using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    private Vector3 _powerUpSpawnPoint;
    private float _timer = 7.0f;

    [SerializeField] private GameObject[] powerupPrefabs;
    [SerializeField] private GroundSpawner _groundSpawner;

    public bool speedUp;
    public bool coinBonus;
    public bool coinMagnet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPowerUp();
    }
    
    private void SpawnPowerUp()
    {
        _timer -= Time.deltaTime;

        int spawnTime = Random.Range(2, 5);
        int index = Random.Range(0, 2);

        if (_timer < 0)
        {
            Debug.Log("spawned");
            _timer += spawnTime;
            Instantiate(powerupPrefabs[index], RandomPositionGenerator(), powerupPrefabs[index].transform.rotation);
        }
    }

    private Vector3 RandomPositionGenerator()
    {
        int lane = Random.Range(-1, 2);
        
        if (lane == 0) _powerUpSpawnPoint.z = -3;
        else if (lane == 1) _powerUpSpawnPoint.z = 0;
        else if(lane == 2) _powerUpSpawnPoint.z = 3;
        
        _powerUpSpawnPoint.x =
            Random.Range(_groundSpawner._nextPointToSpawn.x + - 10, _groundSpawner._nextPointToSpawn.x + 12);

        _powerUpSpawnPoint.y = 2;
        
        return _powerUpSpawnPoint;
    }
    
}
