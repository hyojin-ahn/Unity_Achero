using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMinis : MonoBehaviour
{
    public GameObject MiniFactory;
    public GameObject MiniMom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void MakeMins()
    {
        GameObject Minimis = Instantiate(MiniFactory);
        Minimis.transform.position = MiniMom.transform.position;

        EnemyBossManager.instance.EnemyList.Add(Minimis);
    }
}
