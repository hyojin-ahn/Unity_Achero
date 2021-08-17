using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerprefeb;
    private void Awake()
    {
        GameObject player = Instantiate(playerprefeb);
        player.transform.position = new Vector3(0, 0.5f, -6f);        
    }

}
