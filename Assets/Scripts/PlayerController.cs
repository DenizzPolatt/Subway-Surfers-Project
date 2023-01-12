using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float _runSpeed = 10;
    private bool gameover;
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private bool boosted;
    private bool x2coin;
    private float boosterTimer = 5.0f;
    [SerializeField] private Coin coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _score.ToString();
        if(!gameover) _rigidbody.velocity = Vector3.right * _runSpeed;
        Move();
        BoosterUpdate();
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


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Train(Clone)")
        {
            Debug.Log("Game Over");
            gameover = true;
            _rigidbody.velocity = Vector3.zero;
        }

        if (col.gameObject.name == "Speed(Clone)")
        {
            SpeedUp();
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "Magnet(Clone")
        {
            coinPrefab.magnet = true;
            coinPrefab.MoveTowardsPlayer();
        }

        if (col.gameObject.name == "Coin(Clone)")
        {
            _score += 1;
            if(x2coin) x2Coin();
        }

        if (col.gameObject.name == "x2Coin(Clone)")
        {
            x2coin = true;
        }
    }

    private void SpeedUp()
    {
        boosted = true;
        _runSpeed = 15;
    }

    private void SpeedDown()
    {
        boosted = false;
        _runSpeed = 10;
    }

    private void BoosterUpdate()
    {
        if (boosted)
        {
            boosterTimer -= Time.deltaTime;
            if (boosterTimer < 0)
            {
                SpeedDown();
                x2coin = false;
                coinPrefab.magnet = false;
            }
        }
    }

    private void x2Coin()
    {
        boosted = true;
        _score += 2;
    }

}
