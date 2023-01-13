using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _runSpeed = 10;
    private bool gameover;
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    private bool boosted;
    private bool x2coin;
    private bool magnet;
    private float boosterTimer;
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private MagnetSphere sphere;
    private float _speedUpTimer = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _score.ToString();
        if (!gameover)
        {
            _speedUpTimer -= Time.deltaTime;
            _rigidbody.velocity = Vector3.right * _runSpeed;
            if (_speedUpTimer < 0)
            {
                _runSpeed *= 1.2f;
                _speedUpTimer += 10;
            }
            
        }
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
            GameOver();
        }

        if (col.gameObject.name == "Speed(Clone)")
        {
            SpeedUp();
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "Magnet(Clone)")
        {
            MagnetActive();
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "Coin(Clone)")
        {
            if(x2coin) _score += 2;
            else _score += 1;
        }

        if (col.gameObject.name == "x2Coin(Clone)")
        {
            X2CoinActive();
            Destroy(col.gameObject);
        }
    }

    private void GameOver()
    {
        gameover = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        _rigidbody.velocity = Vector3.zero;
    }

    private void SpeedUp()
    {
        boosterTimer += 5;
        boosted = true;
        _runSpeed *= 1.5f;
    }

    private void SpeedDown()
    {
        boosted = false;
        _runSpeed /= 1.5f;
    }

    private void BoosterUpdate()
    {
        if (boosted)
        {
            boosterTimer -= Time.deltaTime;
            if (boosterTimer < 0)
            {
                SpeedDown();
                X2CoinNotActive();
                MagnetNotActive();
            }
        }
    }
    
    private void X2CoinActive()
    {
        boosterTimer += 5;
        boosted = true;
        x2coin = true;
    }
    
    private void X2CoinNotActive()
    {
        boosted = false;
        x2coin = false;
    }

    private void MagnetActive()
    {
        boosterTimer += 5;
        boosted = true;
        magnet = true;
        sphere._magnetActive = true;
    }

    private void MagnetNotActive()
    {
        boosted = false;
        magnet = false;
        sphere._magnetActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
}
