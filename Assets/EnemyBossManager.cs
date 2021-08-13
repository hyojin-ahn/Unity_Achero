using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossManager : MonoBehaviour
{
    static public EnemyBossManager instance;

    public List<GameObject> EnemyList = new List<GameObject>();
    public float maxHp;
    public float bossHp;

    //HP UI
    public Image hpUI;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        bossHp = maxHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        hpUI.fillAmount = bossHp / maxHp;
    }
}
