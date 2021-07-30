using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheelRoulette : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ãæµ¹");
        Destroy(this.gameObject);        
    }
    
}
