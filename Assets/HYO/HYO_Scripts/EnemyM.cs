using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : MonoBehaviour
{
    public float speed;
    public int Hp;
    public int Power;
    Vector3 dir;

    public GameObject enemy;
    GameObject player;
    public float objDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        player = GameObject.Find("Player");
        objDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
        //Debug.Log(objDistance);

        if(objDistance > 2)
        {
            dir = player.transform.position - transform.position;
            dir.Normalize();
            transform.Translate(dir * speed * Time.deltaTime);
            //transform.position += dir * speed * Time.deltaTime;
        }
        else
        {

        }


        

    }
   
}
