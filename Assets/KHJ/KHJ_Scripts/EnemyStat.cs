using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public GameObject player;
    public int hp;
    public int power;
    public float objDistance;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        objDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        
    }


}
