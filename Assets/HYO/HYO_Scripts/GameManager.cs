using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Clear_Scene");
        }
    }
}
