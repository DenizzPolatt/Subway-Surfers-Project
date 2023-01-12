using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _runSpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = Vector3.right * _runSpeed;
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3f);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rigidbody.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3f);
        }
    }


}
