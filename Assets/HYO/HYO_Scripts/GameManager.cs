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
            GameObject coins = GameObject.Find("Heart(Clone)");
            GameObject pos = GameObject.Find("Player");
           
            coins.transform.position = Vector3.Lerp(coins.transform.position, pos.transform.position,0.5f * Time.deltaTime);
            coins.SetActive(false);

            
            
            //클리어 화면 띄우기
            SceneManager.LoadScene(4);

            
        }
    }
}
