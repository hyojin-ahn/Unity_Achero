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
    float hpValue;              //slider�� ���� value��
    void Start()
    {
        maxHp = enemyname.GetComponent<EnemyStat>().hp;

        currentHp = maxHp;
    }

    void Update()
    {
        //hp�� ����
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Damaged(2);
        HandleHp();
    }

    void HandleHp()
    {
        maxHp = enemyname.GetComponent<EnemyStat>().hp;
        //hpBar�� ���� 0~1 ������ ���� ���� ����hp/�ִ�hp������ ���� �� ����
        hpValue = currentHp / maxHp;
        //�������� Mathf.Lerp(A,B,t) A�� B������ t��ŭ�� ���� ��ȯ��
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
