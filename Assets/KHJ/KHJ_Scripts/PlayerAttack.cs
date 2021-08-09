using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Player player;
    public GameObject[] AttackPos;
    public GameObject PlayerBullet;
    //���ݼӵ�
    float CurrTime;
    //�����Ƽ
    bool Front2 = false;
    bool Multishot = false;
    bool Rear = false;
    public GameObject[] ability;

    //�� Ÿ����
    public GameObject spawn;
    List<GameObject> EnemyList = new List<GameObject>();
    public GameObject CurrTarget;

    

    void Start()
    {
        player = gameObject.GetComponent<Player>();
        spawn = GameObject.Find("spawn");
        if(spawn != null)
            EnemyList = spawn.GetComponent<MakeEnemy>().EnemyList;

    }

    void Update()
    {
        //����� �� Ž��
        DetectNearestTarget();        
        //����� ���� �ִٸ� ����
        CurrTime += Time.deltaTime;
        if(CurrTarget != null)
        {
            //���� �ð����� ����
            if (CurrTime > player.FireTime)
                Fire();
        }



        //���� �׽�Ʈ��
        if (Input.GetMouseButtonDown(0))
        {
            if(Multishot)
                StartCoroutine("FireTwice");
            else
                Fire();
        }
            
   
        //�����Ƽ �׽�Ʈ��
        if (Input.GetKeyDown(KeyCode.Alpha7))
            if (Front2)
            {
                Front2 = false;
                ability[0].SetActive(false);
            }
            else
            {
                Front2 = true;
                ability[0].SetActive(true);
            }

        if (Input.GetKeyDown(KeyCode.Alpha8))
            if (Multishot)
            {
                Multishot = false;
                ability[1].SetActive(false);
            }
            else
            {
                Multishot = true;
                ability[1].SetActive(true);
            }

        if (Input.GetKeyDown(KeyCode.Alpha9))
            if (Rear)
            {
                Rear = false;
                ability[2].SetActive(false);
            }
            else
            {
                Rear = true;
                ability[2].SetActive(true);
            }

    }

    
    void Fire()
    {

        GameObject bullet = Instantiate(PlayerBullet);
        //�Ѿ� �����        
        if (Front2 == true) 
        {
            SetBullet(bullet, 1);
            GameObject bullet1 = Instantiate(PlayerBullet);
            SetBullet(bullet1, 2);
        }
        else if (Front2 == false)
        {            
            SetBullet(bullet, 0);
        }

        if(Rear == true)
        {
            GameObject bullet1 = Instantiate(PlayerBullet);
            SetBullet(bullet1, 3);
            bullet1.transform.forward = Vector3.back;
        }

        //���� �ð����� �߻�
        CurrTime = 0;
    }

    void SetBullet(GameObject bullet, int pos)
    {
        bullet.transform.position = AttackPos[pos].transform.position;
        if (CurrTarget != null)
        {
            //Ÿ�� �������� �Ѿ� ���� ����
            Vector3 firedir = CurrTarget.transform.position - transform.position;
            bullet.GetComponent<PlayerBulletMove>().dir = firedir.normalized;
        }
        else if (CurrTarget == null)
        {
            bullet.GetComponent<PlayerBulletMove>().dir = Vector3.forward;
        }
        //�Ѿ˿� ������ �Ǿ ���
        bullet.GetComponent<PlayerBulletMove>().power = gameObject.GetComponent<Player>().PlayerPower;

    }


    void DetectNearestTarget()
    {
        int ResultIndex = -1;
        float tmpDistance = 1000f;
        for(int i = 0; i < EnemyList.Count; i++)
        {
            float currDistance = 10000;
            //����ִ� �� �߿���
            if(EnemyList[i].activeSelf == true)
                currDistance = EnemyList[i].gameObject.GetComponent<EnemyStat>().objDistance;
            //���� ����� �� ã��
            if (tmpDistance > currDistance)
            {
                tmpDistance = currDistance;                
                ResultIndex = i;
            }
        }

        //���� ���� ���ٸ�
        if(ResultIndex == -1)
        {
            CurrTarget = null;

        }
        else
            CurrTarget = EnemyList[ResultIndex];

    }

    IEnumerator FireTwice()
    {
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
    }

}