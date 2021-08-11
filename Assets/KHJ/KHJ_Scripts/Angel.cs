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
        Debug.Log("met angel");
        AngelManager.SetActive(true);
    }


    public void select1()
    {
        Debug.Log("1");
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);
        skillname.text = "회복";
        skillcontext.text = "HP가 조금 회복되었습니다!";

        AngelManager.SetActive(false);
    }

    public void select2()
    {
        Debug.Log("2");
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);
        skillname.text = "HP 부스트";
        skillcontext.text = "최대 HP가 증가했습니다!";

        AngelManager.SetActive(false);
    }

}
