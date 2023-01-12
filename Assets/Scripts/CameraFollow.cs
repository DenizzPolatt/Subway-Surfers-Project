using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject _player;

    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(_player.transform.position.x + _offset.x, transform.position.y, transform.position.z);
    }
}
