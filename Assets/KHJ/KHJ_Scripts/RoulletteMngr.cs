using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoulletteMngr : MonoBehaviour
{
    public GameObject roulette;
    //�귿��, �귿�� ����ִ� �ǳ�, �귿�ٴ�
    public GameObject RouletteBoard;
    public GameObject RoulettePanel;
    public GameObject Needle;
    //��ų���������� �� ��������Ʈ, �������� �� �̹�����
    public Image[] DisplayItemSlot;
    //�����ϰ� ���÷���
    List<int> ResultIndexList = new List<int>();
    int ItemCnt = 6;
    //��� ǥ��
    public Text skillname;
    public Text skillcontext;
    //���۹�ư
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

            //�귿�� ȸ����Ű��
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
        //ResultIndexList[i] = i�� �迭 ����
        for (int i = 0; i < ItemCnt; i++)
        {
            ResultIndexList.Add(i);
        }
        //����
        for (int i = 0; i < ItemCnt; i++)
        {
            int random = Random.Range(0, ItemCnt);
            int tmp = ResultIndexList[random];
            ResultIndexList[random] = ResultIndexList[i];
            ResultIndexList[i] = tmp;
        }
        //������� �귿�� ����
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
            //�ٴð��� �Ÿ��� ���ؼ� ���� ����� ���� ����
            float currDistance = Vector2.Distance(DisplayItemSlot[i].transform.position, Needle.transform.position);
            if (tmpDistance > currDistance)
            {
                tmpDistance = currDistance;
                ResultIndex = i;
            }
        }

        //�귿 �����
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
