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
        Debug.Log("met angel");
        AngelManager.SetActive(true);
    }


    public void select1()
    {
        Debug.Log("1");
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);
        skillname.text = "ȸ��";
        skillcontext.text = "HP�� ���� ȸ���Ǿ����ϴ�!";

        AngelManager.SetActive(false);
    }

    public void select2()
    {
        Debug.Log("2");
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);
        skillname.text = "HP �ν�Ʈ";
        skillcontext.text = "�ִ� HP�� �����߽��ϴ�!";

        AngelManager.SetActive(false);
    }

}
