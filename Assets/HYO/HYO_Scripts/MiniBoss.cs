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

    // Start is called before the first frame update
    void Start()
    {
        MinibossHp = maxHp;

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
            gameObject.SetActive(false);

        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("pBullet"))
        {
            MinibossHp -= damage;
            hpUI.fillAmount = MinibossHp / maxHp;

        }
    }
}
