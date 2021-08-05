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
    public bool isRotate;

    MakeEnemy spawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponentInChildren<AttackPos>().count == 4)
        {
            //y=-2
            //Vector3 gone= new Vector3(0, -2, 0);
            transform.position = new Vector3(0, -2, 0);
            //Vector3.Lerp(transform.up, gone , 0.5f * Time.deltaTime);

            //spawn = FindObjectOfType<spawn>();

            // 타겟 방향으로 회전함
            Vector3 l_vector = player.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(l_vector).normalized;
            //transform.LookAt(player.transform);
            //isRotate = false;

            transform.forward = Vector3.Lerp(transform.forward, l_vector, 0.5f * Time.deltaTime);

        }
        objDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
        //Debug.Log(objDistance);

    }
}
