
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct Ability
{
    //��ų �̸�(string), ����(string), ��������Ʈ(sprite), ȹ�濩��(bool)
    public string name;
    public string description;
    public Sprite image;
    public bool isActive;
}

public class AbilityManager : MonoBehaviour
{
    //�̱���
    public static AbilityManager instance;
    //����ü
    public Ability[] abilities = new Ability[6];



    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (abilities[0].isActive)
        {
            //���ݷ� �ణ ����
            Player.instance.Strong();
            abilities[0].isActive = false;
        }

        if (abilities[1].isActive)
        {
            //���ݷ� ����
            Player.instance.MoreStrong();
            abilities[1].isActive = false;
        }



        if (abilities[2].isActive)
        {
            //HP�ν�Ʈ
            Player.instance.HpBoost();
            abilities[2].isActive = false;
        }






        DontDestroyOnLoad(gameObject);
    }
}
