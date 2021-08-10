
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
        
    }
}
