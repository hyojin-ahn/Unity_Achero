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
        //Mini가죽으면
        if (MinibossHp <= 0)
        {

            //miniBoss를 만든다 ...miniNum개
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
