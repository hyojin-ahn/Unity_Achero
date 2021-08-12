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
        //�̱���
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //���� �ʱ⼳��
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

        if(other.gameObject.layer == 21)
        {
            playerHp -= 10;
            hpBar.Damaged(10);
        }



    }
    public void Recovery()
    {
        float tmp = hpBar.maxHp * 0.3f;


        playerHp += (int)tmp;

    }

    public void HpBoost()
    {
        float tmp = hpBar.maxHp * 0.2f;

        hpBar.maxHp += tmp;
        playerHp += (int)tmp;
    }
    public void Strong()
    {
        //���ݷ� 15% ����
        float tmp = PlayerPower * 0.15f;        
        PlayerPower += (int)tmp;
    }

    public void MoreStrong()
    {
        //���ݷ� 30% ����
        float tmp = PlayerPower * 0.3f;
        PlayerPower += (int)tmp;
    }
}
