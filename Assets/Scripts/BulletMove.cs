using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    GameObject target;
    
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position - transform.position;
        dir.Normalize();
    }


    // Update is called once per frame
    void Update()
    {
        
        transform.position += dir * speed * Time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
