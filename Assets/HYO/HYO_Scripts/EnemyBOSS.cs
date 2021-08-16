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
    
    //�� ������
    public int damage;
    //miniboss ��
    public int miniNum;
    public int miniNum2;
    //����ȿ��
    public GameObject exploFactory;
    //����
    public GameObject coinFactory;

    bool is700;
    bool is400;


    // Start is called before the first frame update
    void Start()
    {
        bossHp = maxHp;
        EnemyBossManager.instance.EnemyList.Add(gameObject);
        //EnemyBossManager.instance.maxHp += (int)bossHp;
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
        else if (bossHp == 400)
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
            GameObject coin = Instantiate(coinFactory);
            coin.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }
    void CreateExploEffect()
    {
        
        GameObject explo = Instantiate(exploFactory);

        Vector3 i = transform.position;
        i.z = 1.3f;

        explo.transform.position = i;

        ParticleSystem ps = explo.GetComponent<ParticleSystem>();
        
        ps.Play();
       
        Destroy(explo, 0.7f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("pBullet"))
        {
            collision.gameObject.SetActive(false);
            bossHp -= damage;
            EnemyBossManager.instance.bossHp -= damage;
            CreateExploEffect();
        }
    }

}
