using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    Vector3 pos;
    public GameObject player;
    void Start()
    {
        //플레이어 따라다니는 카메라
        player = GameObject.Find("Player_");
        //cam X,Z축은 같고 Y축으로만 이동
        pos = new Vector3(0, 15.5f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + pos;
    }
}
