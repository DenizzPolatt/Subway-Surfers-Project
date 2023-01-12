using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool magnet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            Destroy(gameObject);
        }
    }

    public void MoveTowardsPlayer()
    {
        var player = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10);
        magnet = false;
    }
}
