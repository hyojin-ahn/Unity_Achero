using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    Vector3 pos;
    public GameObject player;
    void Start()
    {
        //�÷��̾� ����ٴϴ� ī�޶�
        player = GameObject.Find("Player_");
        //cam X,Z���� ���� Y�����θ� �̵�
        pos = new Vector3(0, 15.5f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + pos;
    }
}
