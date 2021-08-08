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
    //���ݼӵ�


    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    void Update()
    {
        //����� �� Ž��
        DetectNearestTarget();

        if (Input.GetMouseButtonDown(0))
            Fire();
        
        //����� ���� �ִٸ� ����
        CurrTime += Time.deltaTime;
        if(CurrTarget != null)
        {
            //���� �ð����� ����
            if (CurrTime > player.FireTime)
                Fire();
        }

    }

    
    void Fire()
    {
        //�Ѿ� �����
        GameObject bullet = Instantiate(PlayerBullet);
        bullet.transform.position = AttackPos.transform.position;
        //Ÿ�� �������� �Ѿ� ���� ����
        Vector3 firedir = CurrTarget.transform.position - transform.position;
        bullet.GetComponent<PlayerBulletMove>().dir = firedir.normalized;
        //�Ѿ˿� ������ �Ǿ ���
        bullet.GetComponent<PlayerBulletMove>().power = gameObject.GetComponent<Player>().PlayerPower;

        //���� �ð����� �߻�
        CurrTime = 0;
    }

    void DetectNearestTarget()
    {

    }



}
