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

    //시작버튼
    public GameObject StartButton;

    void Start()
    {
        StartCoroutine(StartRolling());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator StartRolling()
    {
        yield return new WaitForSeconds(2f);
        float rotateSpeed = Random.Range(8f,13f);
        while (true) {
            yield return null;
            if (rotateSpeed <= 0.01f) break;
            rotateSpeed = Mathf.Lerp(rotateSpeed, 0, Time.deltaTime * 0.7f);

            //룰렛판 회전시키기
            RouletteBoard.transform.Rotate(0, 0, rotateSpeed);
        
        }
        DisplayResult();

    }

    void DisplayResult()
    {
        int ResultIndex = -1;
        float tmpDistance = 1000f;
        for (int i = 0; i < ItemCnt; i++)
        {
            float currDistance = Vector2.Distance(DisplayItemSlot[i].transform.position, Needle.transform.position);
            if (tmpDistance > currDistance)
            {
                tmpDistance = currDistance;
                Debug.Log(i + " : " + currDistance);
                ResultIndex = i;
            }
        }
        print("Result Index : "+ResultIndex);
        DisplayItemSlot[ItemCnt].sprite = DisplayItemSlot[ResultIndex].sprite;
        StartButton.SetActive(true);
    }

}
