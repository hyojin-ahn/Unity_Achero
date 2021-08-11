using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isminimi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isminimi = GameObject.Find("MinimiBoss");
        if (isminimi == false)
        {
            //클리어 화면 띄우기
        }
    }
}
