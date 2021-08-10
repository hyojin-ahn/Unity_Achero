using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBOSS : MonoBehaviour
{
    //현재 HP
    float currHp;
    //최대HP
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
        //Boss의 HP가 700보다 작거나 같으면
        if(currHp <= 700)
        {
            //miniBoss를 만든다 ...10개

            //miniBoss가 죽으면 
            //minimiBoss를 또 만든다...5개

            //Boss의 HP가 400보다 작거나 같으면
            //miniBoss를 만든다 ...7개
            //miniBoss가 죽으면 
            //minimiBoss를 또 만든다...4개

            //minimiBoss가 모두 죽으면 
            //클리어 화면을 띄운다
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
