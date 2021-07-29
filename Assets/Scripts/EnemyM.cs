using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : MonoBehaviour
{
    public float speed;
    public GameObject target;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(collision.gameObject);
    //}
}
