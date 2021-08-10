using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int playerHp;
    public int PlayerPower;
    public float FireTime;
    public GameObject PlayerCanvas;
    PlayerHpBar hpBar;
    void Start()
    {
        //ΩÃ±€≈Ê
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //Ω∫≈» √ ±‚º≥¡§
        hpBar = PlayerCanvas.GetComponent<PlayerHpBar>();
        if (hpBar == null)
            Debug.Log("hpBar Missing");
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
            playerHp -= other.gameObject.GetComponent<BulletMove>().power;
            hpBar.Damaged(other.gameObject.GetComponent<BulletMove>().power);
            Destroy(other.gameObject);
        }
    }
}
