using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoulletteMngr : MonoBehaviour
{
    //�귿��, �귿�� ����ִ� �ǳ�, �귿�ٴ�
    public GameObject RouletteBoard;
    public GameObject RoulettePanel;
    public GameObject Needle;
    //��ų���������� �� ��������Ʈ, �������� �� �̹�����
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
        //Board�� Z�� ȸ��


    }
    IEnumerator StartRolling()
    {
        yield return new WaitForSeconds(2f);
    }


}
