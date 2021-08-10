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
    public Image[] DisplayItemSlot;
    //�����ϰ� ���÷���
    public List<int> StartList = new List<int>();
    List<int> ResultIndexList = new List<int>();
    int ItemCnt = 6;
    //��� ǥ��
    public Text skillname;
    public Text skillcontext;
    //���۹�ư
    public GameObject StartButton;

    public void StartRoll()
    {
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
        DisplayResult();
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }

    void Shuffle()
    {
        StartList.Clear();
        ResultIndexList.Clear();
        //StartList[i] = i�� �迭 ����
        for (int i = 0; i < ItemCnt; i++)
        {
            StartList.Add(i);
        }
        //����
        for (int i = 0; i < ItemCnt; i++)
        {
            int random = Random.Range(0, ItemCnt);
            int tmp = StartList[random];
            StartList[random] = StartList[i];
            StartList[i] = tmp;
        }
        //������� �귿�� ����
        for (int i = 0; i < ItemCnt; i++)
        {
            ResultIndexList.Add(StartList[i]);
            print(i + " : " + StartList[i]);
            DisplayItemSlot[i].sprite = AbilityManager.instance.abilities[ResultIndexList[i]].image;
        }
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
                ResultIndex = i;
            }
        }

        //�귿 �����
        print("Result Index : "+ResultIndex);
        DisplayItemSlot[ItemCnt].sprite = DisplayItemSlot[ResultIndex].sprite;
        StartButton.SetActive(false);
    }

    IEnumerator Slot()
    {
        yield return new WaitForSeconds(0.1f);
    }


}
