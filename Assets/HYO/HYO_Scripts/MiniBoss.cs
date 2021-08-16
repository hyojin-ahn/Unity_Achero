using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBoss : MonoBehaviour
{
    //현재 HP
    public float MinibossHp;
    //최대HP
    public float maxHp;
    //HP UI
    public Image hpUI;
    //들어갈 데미지
    public int damage;
    //miniboss 수
    public int miniNum;
    //폭발효과
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
        //Mini가죽으면
        if (MinibossHp <= 0)
        {

            //miniBoss를 만든다 ...miniNum개
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
