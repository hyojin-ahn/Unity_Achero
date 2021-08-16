using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBoss : MonoBehaviour
{
    //���� HP
    public float MinibossHp;
    //�ִ�HP
    public float maxHp;
    //HP UI
    public Image hpUI;
    //�� ������
    public int damage;
    //miniboss ��
    public int miniNum;
    //����ȿ��
    public GameObject exploFactory;
    public GameObject coinFactory;

    

    // Start is called before the first frame update
    void Start()
    {
        MinibossHp = maxHp;
        //EnemyBossManager.instance.maxHp += (int)MinibossHp;


    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("MakeMinimi");
        MakeMinimis gogo = go.GetComponent<MakeMinimis>();
        //Mini��������
        if (MinibossHp <= 0)
        {

            //miniBoss�� ����� ...miniNum��
            for (int i = 0; i <= miniNum; i++)
            {
                gogo.MakeMinmis();
            }
            GameObject coin = Instantiate(coinFactory);
            coin.transform.position = transform.position;
            gameObject.SetActive(false);

        }
       
    }
    void CreateExploEffect()
    {

        GameObject explo = Instantiate(exploFactory);

        Vector3 i = transform.position;
        //i.z = 1.3f;

        explo.transform.position = i;

        ParticleSystem ps = explo.GetComponent<ParticleSystem>();

        ps.Play();

        Destroy(explo, 0.7f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("pBullet"))
        {
            MinibossHp -= damage;
            hpUI.fillAmount = MinibossHp / maxHp;
            EnemyBossManager.instance.bossHp -= damage;
            CreateExploEffect();
        }
    }
}
