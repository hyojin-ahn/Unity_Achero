using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angel : MonoBehaviour
{
    public GameObject AngelManager;
    //결과 표시
    public Text skillname;
    public Text skillcontext;

    private void OnTriggerEnter(Collider other)
    {
        AngelManager.SetActive(true);
    }


    public void select1()
    {
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);
        skillname.text = "회복";
        skillcontext.text = "<color=green>HP</color>가 조금 회복되었습니다!";

        Player.instance.Recovery();

        AngelManager.SetActive(false);
        Destroy(gameObject);
    }

    public void select2()
    {
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);
        skillname.text = "HP 부스트";
        skillcontext.text = "<color=green>최대 HP</color>가 증가했습니다!";

        Player.instance.HpBoost();

        AngelManager.SetActive(false);
        Destroy(gameObject);
    }

}
