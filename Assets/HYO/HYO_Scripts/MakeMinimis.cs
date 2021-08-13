using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMinimis : MonoBehaviour
{
    public GameObject MinimiFactory;
    public GameObject MinimiMom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeMinmis()
    {
        GameObject Minimis = Instantiate(MinimiFactory);
        Minimis.transform.position = MinimiMom.transform.position;

        
        EnemyBossManager.instance.EnemyList.Add(Minimis);
    }
}
