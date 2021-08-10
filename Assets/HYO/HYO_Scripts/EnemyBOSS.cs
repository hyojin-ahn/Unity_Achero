using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBOSS : MonoBehaviour
{
    //���� HP
    float currHp;
    //�ִ�HP
    public float maxHp;

    public Image hpUI;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        currHp = maxHp;

    }

    // Update is called once per frame
    void Update()
    {
        //Boss�� HP�� 700���� �۰ų� ������
        if(currHp <= 700)
        {
            //miniBoss�� ����� ...10��

            //miniBoss�� ������ 
            //minimiBoss�� �� �����...5��

            //Boss�� HP�� 400���� �۰ų� ������
            //miniBoss�� ����� ...7��
            //miniBoss�� ������ 
            //minimiBoss�� �� �����...4��

            //minimiBoss�� ��� ������ 
            //Ŭ���� ȭ���� ����
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("pBullet"))
        {
            currHp -= damage;
            hpUI.fillAmount = currHp / maxHp;           

        }
    }

}
