using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ground;
    private Vector3 _nextPointToSpawn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnGround();
        SpawnGround();
        SpawnGround();
        SpawnGround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnGround()
    {
        GameObject temp = Instantiate(_ground, _nextPointToSpawn, Quaternion.identity);
        _nextPointToSpawn = temp.transform.GetChild(4).transform.position;
        Destroy(temp, 5);
    }
}
