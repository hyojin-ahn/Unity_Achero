using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoulletteMngr : MonoBehaviour
{
    public GameObject roulette;
    //룰렛판, 룰렛이 들어있는 판넬, 룰렛바늘
    public GameObject RouletteBoard;
    public GameObject RoulettePanel;
    public GameObject Needle;
    //스킬아이콘으로 쓸 스프라이트, 아이콘이 들어갈 이미지들
    public Image[] DisplayItemSlot;
    //랜덤하게 디스플레이
    List<int> ResultIndexList = new List<int>();
    int ItemCnt = 6;
    //결과 표시
    public Text skillname;
    public Text skillcontext;
    //시작버튼
    public GameObject StartButton;

    public void StartRoll()
    {
        StartButton.SetActive(false);
        Shuffle();
        StartCoroutine(Rolling());
    }

    public void StartSlot()
    {
        StartCoroutine(Slot());
    }

    IEnumerator Rolling()
    {
        float rotateSpeed = Random.Range(8f,13f);
        while (true) {
            yield return null;
            if (rotateSpeed <= 0.01f) break;
            rotateSpeed = Mathf.Lerp(rotateSpeed, 0, Time.deltaTime * 0.7f);

            //룰렛판 회전시키기
            RouletteBoard.transform.Rotate(0, 0, rotateSpeed);
        
        }
        int Resultindex = DisplayResult();
        yield return new WaitForSeconds(1.2f);
        GetAbilityUI(Resultindex);
        gameObject.SetActive(false);
        Destroy(roulette);
    }

    void Shuffle()
    {
        ResultIndexList.Clear();
        //ResultIndexList[i] = i인 배열 생성
        for (int i = 0; i < ItemCnt; i++)
        {
            ResultIndexList.Add(i);
        }
        //셔플
        for (int i = 0; i < ItemCnt; i++)
        {
            int random = Random.Range(0, ItemCnt);
            int tmp = ResultIndexList[random];
            ResultIndexList[random] = ResultIndexList[i];
            ResultIndexList[i] = tmp;
        }
        //결과값을 룰렛에 적용
        for (int i = 0; i < ItemCnt; i++)
        {
            DisplayItemSlot[i].sprite = AbilityManager.instance.abilities[ResultIndexList[i]].image;
        }
    }


    int DisplayResult()
    {        
        int ResultIndex = -1;
        float tmpDistance = 1000f;
        for (int i = 0; i < ItemCnt; i++)
        {
            //바늘과의 거리를 비교해서 가장 가까운 슬롯 선택
            float currDistance = Vector2.Distance(DisplayItemSlot[i].transform.position, Needle.transform.position);
            if (tmpDistance > currDistance)
            {
                tmpDistance = currDistance;
                ResultIndex = i;
            }
        }

        //룰렛 결과값
        print("Result Index : " + ResultIndex);
        DisplayItemSlot[ItemCnt].sprite = DisplayItemSlot[ResultIndex].sprite;
        AbilityManager.instance.abilities[ResultIndexList[ResultIndex]].isActive = true;        
        return ResultIndexList[ResultIndex];
    }

    void GetAbilityUI(int index)
    {
        skillname.gameObject.SetActive(true);
        skillcontext.gameObject.SetActive(true);

        skillname.text = AbilityManager.instance.abilities[index].name;
        skillcontext.text = AbilityManager.instance.abilities[index].description;
        
    }

    IEnumerator Slot()
    {
        yield return new WaitForSeconds(0.1f);
    }


}
