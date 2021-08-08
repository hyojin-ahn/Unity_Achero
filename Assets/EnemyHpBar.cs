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
        HandleHp();
    }

    void HandleHp()
    {
        currentHp = enemyname.GetComponent<EnemyStat>().hp;
        //hpBar�� ���� 0~1 ������ ���� ���� ����hp/�ִ�hp������ ���� �� ����
        hpValue = currentHp / maxHp;
        //�������� Mathf.Lerp(A,B,t) A�� B������ t��ŭ�� ���� ��ȯ��
        hpBar.value = Mathf.Lerp(hpBar.value, hpValue, Time.deltaTime * 10);


        if (currentHp <= 0)
        {
            Destroy(enemyname);
        }
    }
}
