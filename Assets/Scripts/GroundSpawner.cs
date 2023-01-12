using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ground;
    public Vector3 _nextPointToSpawn;
    private float timer = 0.50f;

    private List<GameObject> groundsSpawned;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnGround();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnGround();
    }

    private void SpawnGround()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer += 1;
            GameObject temp = Instantiate(_ground, _nextPointToSpawn, Quaternion.identity);
            _nextPointToSpawn = temp.transform.GetChild(4).transform.position;
            //groundsSpawned.Add(temp);
        }
    }

    private void DestroyIf()
    {
        if (groundsSpawned.Count > 30)
        {
            for (int i = 0; i < groundsSpawned.Count; i++)
            {
                Destroy(groundsSpawned[i], 3);
            }
        }
    }

}
