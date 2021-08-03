using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoulletteMngr : MonoBehaviour
{
    //룰렛판, 룰렛이 들어있는 판넬, 룰렛바늘
    public GameObject RouletteBoard;
    public GameObject RoulettePanel;
    public GameObject Needle;
    //스킬아이콘으로 쓸 스프라이트, 아이콘이 들어갈 이미지들
    public Sprite[] SkillSprite;
    public Image[] DisplayItemSlot;

    List<int> StartList = new List<int>();
    List<int> ResultIndexList = new List<int>();
    int ItemCnt = 6;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rolling();        
    }

    void Rolling()
    {
        //Board를 Z축 회전


    }
    IEnumerator StartRolling()
    {
        yield return new WaitForSeconds(2f);
    }


}
