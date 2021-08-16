using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public GameObject player;
    
    public Text Hp;             //화면상에 나타는 hp값
    public Slider hpBar;
    public float maxHp;
    public float currentHp;
    float hpValue;              //slider에 들어가는 value값

    //공격 받았을 때 연출
    public GameObject DamagedValue;

    void Start()
    {
        maxHp = Player.instance.playerHp;
        currentHp = maxHp;
    }

    void Update()
    {
        //플레이어를 따라다니게 함
        //transform.position = player.transform.position;

        //hp값 적용
        HandleHp();
        //hp값을 화면에 적용
        HpDisplay();
    }

    void HandleHp()
    {

        currentHp = Player.instance.playerHp;
        //hpBar의 값은 0~1 사이의 값임 따라서 현재hp/최대hp값으로 구할 수 있음
        hpValue = currentHp / maxHp;
        //선형보간 Mathf.Lerp(A,B,t) A와 B사이의 t만큼의 값을 반환함
        hpBar.value = Mathf.Lerp(hpBar.value, hpValue, Time.deltaTime * 10);
    }

    void HpDisplay()
    {
        //체력이 0보다 작아져도 0으로 표시
        if (currentHp < 0)
            currentHp = 0;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
            Player.instance.playerHp = (int)maxHp;
        }
        Hp.text = currentHp.ToString();
    }

    public void Damaged(int damage)
    {
        StartCoroutine("DamagedAnim");
        DamagedValue.GetComponent<Text>().text = damage.ToString();
        DamagedValue.SetActive(true);
    }

    IEnumerator DamagedAnim()
    {
        yield return new WaitForSeconds(0.5f);
        DamagedValue.SetActive(false);
    }
}
