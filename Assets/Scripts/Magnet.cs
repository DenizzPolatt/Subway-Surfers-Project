using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject coinDetectorObj;
    // Start is called before the first frame update
    void Start()
    {
        coinDetectorObj = GameObject.FindGameObjectWithTag("Coin Detector");
        coinDetectorObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
