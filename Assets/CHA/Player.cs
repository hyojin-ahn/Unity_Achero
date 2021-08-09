using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHp;
    public int PlayerPower;
    public float FireTime;
    void Start()
    {
        playerHp = 1000;
        PlayerPower = 10;
        FireTime = 2f;
    }

    void Update()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == 8)
        {
            Debug.Log("Damage : "+ other.gameObject.GetComponent<BulletMove>().power);
            playerHp -= other.gameObject.GetComponent<BulletMove>().power;
            Destroy(other.gameObject);
        }
    }
}
