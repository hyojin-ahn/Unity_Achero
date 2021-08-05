using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    public GameObject player;
    public Text Hp;             //ȭ��� ��Ÿ�� hp��
    public Slider hpBar;
    public float maxHp;
    public float currentHp;
    float hpValue;              //slider�� ���� value��
    void Start()
    {
        if(gameObject.name.Contains("EnemyM"))
            maxHp = player.GetComponent<EnemyM>().Hp;
        else if(gameObject.name.Contains("EnemyS"))
            maxHp = player.GetComponent<EnemyS>().Hp;


        currentHp = maxHp;
    }

    void Update()
    {
        //�÷��̾ ����ٴϰ� ��
        //transform.position = player.transform.position;

        //hp�� ����
        HandleHp();
        //hp���� ȭ�鿡 ����
        HpDisplay();
    }

    void HandleHp()
    {
        //hpBar�� ���� 0~1 ������ ���� ���� ����hp/�ִ�hp������ ���� �� ����
        hpValue = currentHp / maxHp;
        //�������� Mathf.Lerp(A,B,t) A�� B������ t��ŭ�� ���� ��ȯ��
        hpBar.value = Mathf.Lerp(hpBar.value, hpValue, Time.deltaTime * 10);
    }

    void HpDisplay()
    {
        //ü���� 0���� �۾����� 0���� ǥ��
        if (currentHp < 0)
            currentHp = 0;
        Hp.text = currentHp.ToString();
    }

    public void Damaged(int damage)
    {
        currentHp -= damage;
    }


}
