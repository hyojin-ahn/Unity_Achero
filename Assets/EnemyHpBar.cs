using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    public GameObject enemyname;
    public Slider hpBar;
    public float maxHp;
    public float currentHp;
    float hpValue;              //slider에 들어가는 value값
    void Start()
    {
        maxHp = enemyname.GetComponent<EnemyStat>().hp;

        currentHp = maxHp;
    }

    void Update()
    {
        //hp값 적용
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Damaged(2);
        HandleHp();
    }

    void HandleHp()
    {
        maxHp = enemyname.GetComponent<EnemyStat>().hp;
        //hpBar의 값은 0~1 사이의 값임 따라서 현재hp/최대hp값으로 구할 수 있음
        hpValue = currentHp / maxHp;
        //선형보간 Mathf.Lerp(A,B,t) A와 B사이의 t만큼의 값을 반환함
        hpBar.value = Mathf.Lerp(hpBar.value, hpValue, Time.deltaTime * 10);
    }


    public void Damaged(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Destroy(enemyname);
        }
    }
}
