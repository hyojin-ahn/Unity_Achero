using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    public int Hp;
    public int Power;

    public GameObject enemy;
    GameObject player;
    float objDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        objDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
        Debug.Log(objDistance);
    }
}
