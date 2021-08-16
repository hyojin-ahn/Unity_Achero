using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Player player;
    public GameObject[] AttackPos;
    public GameObject PlayerBullet;
    //공격속도
    float CurrTime;

    //적 타겟팅
    public GameObject spawn;
    public List<GameObject> EnemyList = new List<GameObject>();
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
        //가까운 적 탐색
        DetectNearestTarget();        
        //가까운 적이 있다면 공격
        CurrTime += Time.deltaTime;
        if(CurrTarget != null)
        {
            //일정 시간마다 공격
            if (CurrTime > player.FireTime)
                Fire();
        }

        //공격 테스트용
        if (Input.GetMouseButtonDown(0))
        {
            if(AbilityManager.instance.abilities[3].isActive)
                StartCoroutine("FireTwice");
            else
                Fire();
        }
    }

    
    void Fire()
    {        
        GameObject bullet = Instantiate(PlayerBullet);
        //총알 만들기        
        if (AbilityManager.instance.abilities[4].isActive == true) 
        {
            SetBullet(bullet, 1);
            GameObject bullet1 = Instantiate(PlayerBullet);
            SetBullet(bullet1, 2);
        }
        else if (AbilityManager.instance.abilities[4].isActive == false)
        {            
            SetBullet(bullet, 0);
        }

        if(AbilityManager.instance.abilities[5].isActive == true)
        {
            GameObject bullet1 = Instantiate(PlayerBullet);
            SetBullet(bullet1, 3);
            bullet1.transform.forward = Vector3.back;
        }

        //일정 시간마다 발사
        CurrTime = 0;
    }

    void SetBullet(GameObject bullet, int pos)
    {
        bullet.transform.position = AttackPos[pos].transform.position;
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
    }


    void DetectNearestTarget()
    {
        int ResultIndex = -1;
        float tmpDistance = 1000f;
        for(int i = 0; i < EnemyList.Count; i++)
        {
            float currDistance = 10000;
            //살아있는 적 중에서
            if(EnemyList[i].activeSelf == true)
                currDistance = EnemyList[i].gameObject.GetComponent<EnemyStat>().objDistance;
            //제일 가까운 적 찾기
            if (tmpDistance > currDistance)
            {
                tmpDistance = currDistance;                
                ResultIndex = i;
            }
        }
        //남은 적이 없다면
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
