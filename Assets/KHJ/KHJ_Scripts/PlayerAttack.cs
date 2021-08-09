using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Player player;
    public GameObject AttackPos;
    public GameObject PlayerBullet;
    public GameObject CurrTarget;
    float CurrTime;
    //공격속도


    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    void Update()
    {
        //가까운 적 탐색
        DetectNearestTarget();

        if (Input.GetMouseButtonDown(0))
            Fire();
        
        //가까운 적이 있다면 공격
        CurrTime += Time.deltaTime;
        if(CurrTarget != null)
        {
            //일정 시간마다 공격
            if (CurrTime > player.FireTime)
                Fire();
        }

    }

    
    void Fire()
    {

        //총알 만들기
        GameObject bullet = Instantiate(PlayerBullet);
        bullet.transform.position = AttackPos.transform.position;
        if (CurrTarget != null)
        {
            //타겟 방향으로 총알 방향 설정
            Vector3 firedir = CurrTarget.transform.position - transform.position;
            bullet.GetComponent<PlayerBulletMove>().dir = firedir.normalized;
        }
        else if (CurrTarget == null)
        {            
            bullet.GetComponent<PlayerBulletMove>().dir = Vector3.forward;
        }
        //총알에 데미지 실어서 쏘기
        bullet.GetComponent<PlayerBulletMove>().power = gameObject.GetComponent<Player>().PlayerPower;

        //일정 시간마다 발사
        CurrTime = 0;
    }

    void DetectNearestTarget()
    {

    }



}
