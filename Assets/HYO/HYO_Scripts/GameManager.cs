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
       
        if (EnemyBossManager.instance.bossHp<=0)
        {
            //Ŭ���� ȭ�� ����
            SceneManager.LoadScene(4);
        }
    }
}
