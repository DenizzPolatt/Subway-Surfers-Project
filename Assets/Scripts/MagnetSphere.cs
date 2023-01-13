using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MagnetSphere : MonoBehaviour
{
    public bool _magnetActive;

    [SerializeField] private Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _player.position;
    }

    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("trigger");
        if (!_magnetActive) return;
        
        var coin = collider.GetComponent<Coin>();

        if (coin != null)
        {
            Debug.Log("coin");
            coin.MoveTowardsPlayer();
        }
    }
}
