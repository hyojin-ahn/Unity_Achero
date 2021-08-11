using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBOSS : MonoBehaviour
{
    //���� HP
    public float bossHp;
    //�ִ�HP
    public float maxHp;
    //HP UI
    public Image hpUI;
    //�� ������
    public int damage;
    //miniboss ��
    public int miniNum;
    public int miniNum2;

    bool is700;
    bool is400;

    public List<GameObject> EnemyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        bossHp = maxHp;
        EnemyList.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("MakeMini");
        MakeMinis gogo = go.GetComponent<MakeMinis>();
        //Boss�� HP�� 700���� �۰ų� ������
        if (bossHp == 700)
        {
            if (is700 == false)
            {
                is700 = true;

                //miniBoss�� ����� ...miniNum��
                for (int i = 0; i <= miniNum; i++)
                {
                    gogo.MakeMins();
                }
            }
            
  
        }
        //Boss�� HP�� 400���� �۰ų� ������       
        else if (bossHp <= 400)
        {
            if (is400 == false)
            {
                is400 = true;
                //miniBoss�� ����� ...miniNum2��
                for (int i = 0; i <= miniNum2; i++)
                {
                    gogo.MakeMins();
                }
            }
           
        }
        else if (bossHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("pBullet"))
        {
            collision.gameObject.SetActive(false);
            bossHp -= damage;
            hpUI.fillAmount = bossHp / maxHp;           

        }
    }

}
