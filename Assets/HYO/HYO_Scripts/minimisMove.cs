using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimisMove : MonoBehaviour
{
    public float speed;
    GameObject player;
    public GameObject minimis;
    public float objDistance;
    
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        objDistance = Vector3.Distance(minimis.transform.position, player.transform.position);
        //Debug.Log(objDistance);

        if (objDistance > 6)
        {
            dir = player.transform.position - transform.position;
            dir.Normalize();
            transform.Translate(dir * speed * Time.deltaTime);
                     
        }
        else if(objDistance >= 3)
        {
            transform.position = player.transform.position;
            return;
        }
    }
}
