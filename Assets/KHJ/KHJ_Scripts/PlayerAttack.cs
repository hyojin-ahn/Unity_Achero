using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackPos;
    public GameObject PlayerBullet;
    public GameObject CurrTarget;
    float CurrTime;



    void Start()
    {
        
    }

    void Update()
    {
        DetectNearestTarget();
        if (Input.GetMouseButtonDown(0))
            Fire();
    }


    void Fire()
    {
        GameObject bullet = Instantiate(PlayerBullet);
        bullet.transform.position = AttackPos.transform.position;

        Vector3 firedir = CurrTarget.transform.position - transform.position;
        bullet.GetComponent<PlayerBulletMove>().dir = firedir.normalized;
        bullet.GetComponent<PlayerBulletMove>().power = gameObject.GetComponent<Player>().PlayerPower;
    }

    void DetectNearestTarget()
    {

    }



}
