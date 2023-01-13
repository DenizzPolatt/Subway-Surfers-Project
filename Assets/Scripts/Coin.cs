using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
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
        Debug.Log("1");
        var player = GameObject.FindObjectOfType<PlayerController>();

        if (Vector3.Distance(transform.position, player._rigidbody.position) < 10)
        {
            transform.position = Vector3.Lerp(transform.position, player._rigidbody.position, 10 * Time.deltaTime);
        }
    }
}
