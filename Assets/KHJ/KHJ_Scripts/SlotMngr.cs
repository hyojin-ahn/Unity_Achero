using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMngr : MonoBehaviour
{
    public GameObject[] SlotSkills;
    public Button[] Slot;
    public Text[] Skillnames;

    Sprite[] SkillSprite = new Sprite[12];

    [System.Serializable]
    public class DisplayItemSlot
    {
        public List<Image> SlotSprite = new List<Image>();
    }
    public DisplayItemSlot[] displayItemSlots;

    public Image DisplayResultImage;

    public List<int> StartList = new List<int>();
    public List<int> ResultIndexList = new List<int>();

    //슬롯 위에 올라갈 총 스킬의 갯수
    int ItemCnt = 3;

    //결과
    int SelectIndex = -1;
    public Text SkillName;
    public Text SkillContext;


    void Start()
    {
        for(int i = 0; i < ItemCnt * Slot.Length; i++)
        {
            StartList.Add(i);
            if (i < 6)
            {
                SkillSprite[i] = AbilityManager.instance.abilities[i].image;
            }
            else
            {
                SkillSprite[i] = AbilityManager.instance.abilities[i % 6].image;
            }
        }
        for(int i = 0; i < Slot.Length; i++)
        {
            //스킬 순서를 랜덤하게 셋팅하고 당첨된 스킬인덱스 저장
            for(int j = 0; j < ItemCnt; j++)
            {
                Slot[i].interactable = false;

                int randomIndex = Random.Range(0, StartList.Count);
                if(i==0 && j==1 || i==1 && j == 0 || i == 2 && j == 2)
                {
                    ResultIndexList.Add(StartList[randomIndex]);
                }
                displayItemSlots[i].SlotSprite[j].sprite = SkillSprite[StartList[randomIndex]];
                if (j == 0)
                {
                    displayItemSlots[i].SlotSprite[ItemCnt].sprite = SkillSprite[StartList[randomIndex]];
                }
                StartList.RemoveAt(randomIndex);
            }

        }
        for(int i = 0; i < Slot.Length; i++)
        {
            StartCoroutine(StartSlot(i));
        }        
    }

    int[] answer = { 2, 3, 1 };

    IEnumerator StartSlot(int SlotIndex)
    {
        yield return null;
        for (int i = 0; i < (ItemCnt * (6 + SlotIndex*4) + answer[SlotIndex]) * 2; i++)
        {
            SlotSkills[SlotIndex].transform.localPosition -= new Vector3(0, 50f, 0);
            if (SlotSkills[SlotIndex].transform.localPosition.y < 50f)
            {
                SlotSkills[SlotIndex].transform.localPosition += new Vector3(0, 300f, 0);
            }

            yield return new WaitForSeconds(0.02f);
        }
        for (int i = 0; i < ItemCnt; i++)
        {
            Slot[i].interactable = true;
            yield return new WaitForSeconds(0.3f);
            Skillnames[i].text = AbilityManager.instance.abilities[ResultIndexList[i] % 6].name;            
        }
    }
    public void ClickBtn(int index)
    {
        DisplayResultImage.sprite = SkillSprite[ResultIndexList[index]];
        SelectIndex = index;
        StartCoroutine(EndSlot());
    }

    IEnumerator EndSlot()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        AbilityManager.instance.abilities[ResultIndexList[SelectIndex] % 6].isActive = true;

        SkillName.gameObject.SetActive(true);
        SkillContext.gameObject.SetActive(true);
        
        SkillName.text = AbilityManager.instance.abilities[ResultIndexList[SelectIndex] % 6].name;
        SkillContext.text = AbilityManager.instance.abilities[ResultIndexList[SelectIndex] % 6].description;
    }



}
