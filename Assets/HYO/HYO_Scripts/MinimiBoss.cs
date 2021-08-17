using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimiBoss : MonoBehaviour
{
    //���� HP
    public float MinimibossHp;
    //�ִ�HP
    public float maxHp;
    //HP UI
    public Image hpUI;
    //�� ������
    public int damage;
    //����ȿ��
    public GameObject exploFactory;
    public GameObject coinFactory;

    // Start is called before the first frame update
    void Start()
    {
        MinimibossHp = maxHp;
        //EnemyBossManager.instance.maxHp += (int)MinimibossHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (MinimibossHp <= 0)
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
            MinimibossHp -= damage;
            hpUI.fillAmount = MinimibossHp / maxHp;
            EnemyBossManager.instance.bossHp -= damage;
            CreateExploEffect();

        }
    }
}