using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct Ability
{
    public string name;
    public string description;
    public Sprite image;

}

public class AbilityManager : MonoBehaviour
{
    //�̱���
    public static AbilityManager instance;
    //��ų �̸�(string), ����(string), ��������Ʈ(sprite), ȿ��(code)
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
