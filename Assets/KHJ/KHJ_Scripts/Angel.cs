using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angel : MonoBehaviour
{
    public GameObject AngelManager;
    //��� ǥ��
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
        skillname.text = "ȸ��";
        skillcontext.text = "<color=green>HP</color>�� ���� ȸ���Ǿ����ϴ�!";

        Player.instance.Recovery();

        AngelManager.SetActive(false);
        Destroy(gameObject);
    }

    public void select2()
    {
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);
        skillname.text = "HP �ν�Ʈ";
        skillcontext.text = "<color=green>�ִ� HP</color>�� �����߽��ϴ�!";

        Player.instance.HpBoost();

        AngelManager.SetActive(false);
        Destroy(gameObject);
    }

}
