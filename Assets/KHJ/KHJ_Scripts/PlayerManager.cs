using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{



    public GameObject playerprefeb;
    void Start()
    {
        GameObject player = Instantiate(playerprefeb);
        player.transform.position = new Vector3(0, 2.5f, -6f);
    }

    void Update()
    {
        
    }
}
