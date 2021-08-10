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
    //싱글톤
    public static AbilityManager instance;
    //스킬 이름(string), 설명(string), 스프라이트(sprite), 효과(code)
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
        
    }
}
