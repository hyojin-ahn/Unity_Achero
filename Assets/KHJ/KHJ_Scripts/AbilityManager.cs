
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct Ability
{
    //스킬 이름(string), 설명(string), 스프라이트(sprite), 획득여부(bool)
    public string name;
    public string description;
    public Sprite image;
    public bool isActive;
}

public class AbilityManager : MonoBehaviour
{
    //싱글톤
    public static AbilityManager instance;
    //구조체
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
            //공격력 약간 증가
            Player.instance.Strong();
            abilities[0].isActive = false;
        }

        if (abilities[1].isActive)
        {
            //공격력 증가
            Player.instance.MoreStrong();
            abilities[1].isActive = false;
        }



        if (abilities[2].isActive)
        {
            //HP부스트
            Player.instance.HpBoost();
            abilities[2].isActive = false;
        }






        DontDestroyOnLoad(gameObject);
    }
}
