using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    public int Hp;
    public int Power;

    public GameObject enemy;
    GameObject player;
    public float objDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Vector3 l_vector = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(l_vector).normalized;
        // 타겟 방향으로 회전함
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        objDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
        //Debug.Log(objDistance);
    }
}
