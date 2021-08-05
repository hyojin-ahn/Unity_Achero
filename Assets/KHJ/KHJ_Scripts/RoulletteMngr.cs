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

    //���۹�ư
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

            //�귿�� ȸ����Ű��
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
